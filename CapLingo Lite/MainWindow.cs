using Domains;
using Utilities;

namespace CapLingo_Lite
{
    public partial class MainWindow : Form
    {
        private List<Subtitle> _subtitles;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BrowseDraftContentFile_Btn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Select a subtitle file";
            openFileDialog.InitialDirectory = SubtitleFilePath_TextBox.Text;
            openFileDialog.Filter = "JSON (*.json)|*.json|SRT (*.srt)|*.srt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _subtitles = Path.GetExtension(openFileDialog.FileName) switch
                    {
                        ".json" => await SubtittleHelper.ExtractCapcutSubtittleAsync(openFileDialog.FileName),
                        ".srt" => await SubtittleHelper.ExtractSrtAsync(openFileDialog.FileName),
                        _ => throw new NotSupportedException("File extension not supported")
                    };

                    if (_subtitles == null || _subtitles.Count == 0)
                    {
                        MessageBox.Show("No subtitles found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_subtitles.Any(s => s.StartTime > new TimeSpan(0, 30, 0)))
                    {
                        MessageBox.Show("Subtitles with start time greater than 30 minutes are not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SubtitleFilePath_TextBox.Text = openFileDialog.FileName;
                    DialoguesTable.DataSource = _subtitles;
                    ExportSrt_Btn.Enabled = EnableMinimizeSubtitle_Checkbox.Enabled = TranslateBtn.Visible = _subtitles != null && _subtitles.Count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SubtitleFilePath_TextBox.Text = @$"C:\Users\{Environment.UserName}\AppData\Local\CapCut\User Data\Projects\com.lveditor.draft\";
        }

        private async void ExportSrt_Btn_Click(object sender, EventArgs e)
        {
            if (DialoguesTable.DataSource is not List<Subtitle> subtitles)
            {
                MessageBox.Show("No subtitles to export", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EnableMinimizeSubtitle_Checkbox.Checked)
            {
                subtitles = SubtittleHelper.MinimizeDialogues(subtitles);
            }

            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "SRT files (*.srt)|*.srt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.DefaultExt = "srt";
            saveFileDialog.FileName = $"{DateTime.Now.Ticks}.srt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await SubtittleHelper.ExportAsync(subtitles, saveFileDialog.FileName);
                    MessageBox.Show("Subtitles exported successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TranslateBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Select a video file for translation";
            openFileDialog.Filter = "Video (*.mp4;*.avi;*.mov;*.wmv;*.mpeg)|*.mp4;*.avi;*.mov;*.wmv;*.mpeg";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show("The video file must be assosiated to the subtitle content.\nAre you sure to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Cache.OriginalSubtitle = _subtitles;
                    Cache.VideoFilePath = openFileDialog.FileName;
                    Cache.SubtitleFilePath = SubtitleFilePath_TextBox.Text;
                    var translationSettings = new TranslationSettingsWindow();
                    translationSettings.ShowDialog();
                }
            }
        }
    }
}
