using Domains;
using GenAI;
using System.Data;
using System.Globalization;
using System.Text;
using Translator;
using Translator.Models;
using Utilities;

namespace CapLingo_Lite
{
    public partial class TranslationSettingsWindow : Form
    {
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
            var analyst = new VideoAnalyst();
            try
            {
                LogTextBox.Text += "Preparing file to upload...";
                GoogleVideoUploader.GoogleApiKey = GeminiApiKey_TextBox.Text.Trim();
                var uploadUrl = await GoogleVideoUploader.InitiateResumableUpload(Cache.VideoFilePath);

                LogTextBox.Text += "\nSending video to Gemini...";
                var fileUri = await GoogleVideoUploader.UploadVideoData(uploadUrl, Cache.VideoFilePath);
                var fileId = fileUri.Replace("https://generativelanguage.googleapis.com/v1beta/files/", string.Empty);

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
                LogTextBox.Text += "Analyzing video...";
                await analyst.AnalyzeVideo(Cache.VideoFilePath, 5);
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"\nFailed to analyze the video: {ex.Message}";
                MessageBox.Show(ex.Message, "Failed to analyze the video", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogTextBox.Clear();
            var logBuilder = new StringBuilder();

            logBuilder.AppendLine($"Primary language of the video: {analyst.VideoAnalysis.AudioLanguage}");
            logBuilder.AppendLine("====================================================");
            logBuilder.AppendLine(analyst.VideoAnalysis.Summarization);
            logBuilder.AppendLine("====================================================");
            logBuilder.AppendLine($"Found {analyst.VideoAnalysis.Characters.Count} characters:");
            for (int i = 0; i < analyst.VideoAnalysis.Characters.Count; i++)
            {
                var character = analyst.VideoAnalysis.Characters[i];
                logBuilder.AppendLine($"   {i + 1}. {character.Alias}:");
                logBuilder.AppendLine($"   - Appearance: {character.Appearance}");
                logBuilder.AppendLine($"   - Speaking Tone: {character.SpeakingTone}");
                logBuilder.AppendLine();
            }
            logBuilder.AppendLine("====================================================");
            logBuilder.AppendLine($"The video can be separated into {analyst.VideoAnalysis.Chapters.Count} chapters:");
            for (int i = 0; i < analyst.VideoAnalysis.Chapters.Count; i++)
            {
                var chapter = analyst.VideoAnalysis.Chapters[i];
                logBuilder.AppendLine($"   {i + 1}. {chapter.StartTime} to {chapter.EndTime}:");
                logBuilder.AppendLine($"   - {chapter.Description}");
                logBuilder.AppendLine();
            }
            logBuilder.AppendLine("====================================================");
            var analysisLog = logBuilder.ToString();

            foreach (var word in analysisLog)
            {
                LogTextBox.Text += word;
                await Task.Delay(10);
            }

            var translationTasks = analyst.VideoAnalysis.Chapters.Select(TranslateChapter);
            var results = await Task.WhenAll(translationTasks);

            Cache.TranslatedSubtitle = results
                .Where(r => r != null)
                .SelectMany(subtitle => subtitle)
                .OrderBy(subtitle => subtitle.StartTime)
                .ToList();

        }

        private async Task<List<Subtitle>?> TranslateChapter(Chapter chapter)
        {
            LogTextBox.Text += $"Translating chapter {chapter.StartTime} to {chapter.EndTime} . . .";

            try
            {
                await Task.Delay(10);
                var results = new List<Subtitle>();

                LogTextBox.Text += $"Finished translating chapter {chapter.StartTime} to {chapter.EndTime}.";

                return results;
            }
            catch (Exception ex)
            {
                LogTextBox.Text += $"Failed to translate chapter {chapter.StartTime} to {chapter.EndTime}: {ex.Message}";
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
            }
            else
            {
                MessageBox.Show("Invalid API key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
