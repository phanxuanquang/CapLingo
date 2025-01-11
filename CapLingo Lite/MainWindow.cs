using Capcut_Helpers;

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
            openFileDialog.InitialDirectory = DraftContentFilePath_TextBox.Text;
            openFileDialog.Filter = "JSON (*.json)|*.json";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _subtitles = await Ulti.GetSubtittleAsync(openFileDialog.FileName);
                    DraftContentFilePath_TextBox.Text = openFileDialog.FileName;
                    DialoguesTable.DataSource = _subtitles;
                    ExportSrt_Btn.Enabled = EnableMinimizeSubtitle_Checkbox.Enabled = _subtitles != null && _subtitles.Count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DraftContentFilePath_TextBox.Text = @$"C:\Users\{Environment.UserName}\AppData\Local\CapCut\User Data\Projects\com.lveditor.draft\";
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
                subtitles = Ulti.MinimizeContent(subtitles);
            }

            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "SRT files (*.srt)|*.srt";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await Ulti.ExportSubtittleAsync(subtitles, saveFileDialog.FileName);
                    MessageBox.Show("Subtitles exported successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
