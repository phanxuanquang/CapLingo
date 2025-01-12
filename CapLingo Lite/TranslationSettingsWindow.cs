using Domains;
using GenAI;
using System.Data;
using System.Globalization;
using System.Text;
using Translator.Models;
using Utilities;

namespace CapLingo_Lite
{
    public partial class TranslationSettingsWindow : Form
    {
        private string _fileUri;
        public TranslationSettingsWindow()
        {
            InitializeComponent();
        }

        private void TranslationSettingsWindow_Load(object sender, EventArgs e)
        {
            TargetLanguage_ComboBox.DataSource = CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(culture => culture.EnglishName).ToList();
            TargetLanguage_ComboBox.SelectedItem = "Vietnamese";
        }

        private async void Start_Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GeminiApiKey_TextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter the Gemini API key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EnableMinimizeSubtitle_Checkbox.Checked)
            {
                Cache.OriginalSubtitle = SubtittleHelper.MinimizeDialogues(Cache.OriginalSubtitle);
                LogTextBox.Text += "Dialogues minimized\n";
            }

            try
            {
                LogTextBox.Text += "Preparing file to upload...";
                GoogleVideoUploader.GoogleApiKey = GeminiApiKey_TextBox.Text.Trim();
                var uploadUrl = await GoogleVideoUploader.InitiateResumableUpload(Cache.VideoFilePath);

                LogTextBox.Text += "\nSending video to Gemini...";
                _fileUri = await GoogleVideoUploader.UploadVideoData(uploadUrl, Cache.VideoFilePath);
                var fileId = _fileUri.Replace("https://generativelanguage.googleapis.com/v1beta/files/", string.Empty);

                LogTextBox.Text += "\nProcessing video...";
                var state = await GoogleVideoUploader.GetFileState(fileId);
                while (state == "PROCESSING")
                {
                    LogTextBox.Text += "\nProcessing video...";
                    await Task.Delay(5000);
                    state = await GoogleVideoUploader.GetFileState(fileId);
                }
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to upload the video: {ex.Message}";
                MessageBox.Show(ex.Message, "Failed to upload the video. Please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await Translator.Translator.Prepare(_fileUri, FileHelper.GetVideoMimeType(Cache.VideoFilePath), TargetLanguage_ComboBox.Text);
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to prepare the documents: {ex.Message}";
                MessageBox.Show(ex.Message, "Failed to prepare the documents", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var analysis = new VideoAnalysis();

            try
            {
                LogTextBox.Text += "Analyzing video...";
                analysis = await Translator.Translator.AnalyzeVideo();
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to analyze the video: {ex.Message}";
                MessageBox.Show(ex.Message, "Failed to analyze the video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogTextBox.Clear();
            LogTextBox.Text = Translator.Translator.VideoAnalysis;

            try
            {
                LogTextBox.Text += "\n====================================================";
                LogTextBox.Text += "\nExtracting translation guideline...";
                await Translator.Translator.ExtractTranslationGuideline();
                LogTextBox.Text += $"\n{Translator.Translator.TranslationGuideline}";
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to extract the tranllation guideline for the video: {ex.Message}";
                MessageBox.Show(ex.Message, "Failed to extract the tranllation guideline for the video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var translationTasks = analysis.Chapters.Select(TranslateChapter);
            var results = await Task.WhenAll(translationTasks);

            Cache.TranslatedSubtitle = results
                .Where(r => r != null)
                .SelectMany(subtitle => subtitle)
                .DistinctBy(s => s.StartTime)
                .OrderBy(subtitle => subtitle.StartTime)
                .ToList();

            var srt = new StringBuilder(Cache.TranslatedSubtitle.Count * 100);

            for (int i = 0; i < Cache.TranslatedSubtitle.Count; i++)
            {
                srt.Append(i + 1).AppendLine()
                   .Append(TimeSpanHelper.AsString(Cache.TranslatedSubtitle[i].StartTime))
                   .Append(" --> ")
                   .Append(TimeSpanHelper.AsString(Cache.TranslatedSubtitle[i].EndTime))
                   .AppendLine()
                   .AppendLine(Cache.TranslatedSubtitle[i].Text)
                   .AppendLine();
            }

            LogTextBox.Text = srt.ToString();
        }

        private async Task<List<Subtitle>?> TranslateChapter(Chapter chapter)
        {
            try
            {
                var subtitles = Cache.OriginalSubtitle
                    .Where(subtitles => TimeSpanHelper.AsTimeSpan(chapter.StartTime) <= subtitles.StartTime && subtitles.EndTime <= TimeSpanHelper.AsTimeSpan(chapter.EndTime))
                    .ToList();

                var translatedSubtitles = await Translator.Translator.TranslateVideo(subtitles);
                return translatedSubtitles;
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to translate the chapter from {chapter.StartTime} to {chapter.EndTime}: {ex.Message}";
                return null;
            }
        }

        private async void ValidateApiKey_Btn_Click(object sender, EventArgs e)
        {
            Gemini.ApiKey = GeminiApiKey_TextBox.Text.Trim();
            var isValidApiKey = (await Gemini.IsValidApiKey()) && Gemini.CanBeGeminiApiKey();
            if (isValidApiKey)
            {
                MessageBox.Show("API key is valid", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Start_Btn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid API key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Start_Btn.Enabled = false;
            }
        }
    }
}
