namespace CapLingo_Lite
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SubtitleFilePath_TextBox = new TextBox();
            BrowseDraftContentFile_Btn = new Button();
            EnableMinimizeSubtitle_Checkbox = new CheckBox();
            DialoguesTable = new DataGridView();
            ExportSrt_Btn = new Button();
            TranslateBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DialoguesTable).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SubtitleFilePath_TextBox
            // 
            SubtitleFilePath_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SubtitleFilePath_TextBox.Location = new Point(13, 0);
            SubtitleFilePath_TextBox.Margin = new Padding(10, 5, 10, 10);
            SubtitleFilePath_TextBox.Multiline = true;
            SubtitleFilePath_TextBox.Name = "SubtitleFilePath_TextBox";
            SubtitleFilePath_TextBox.PlaceholderText = "C:\\Users\\user\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
            SubtitleFilePath_TextBox.ReadOnly = true;
            SubtitleFilePath_TextBox.Size = new Size(1315, 34);
            SubtitleFilePath_TextBox.TabIndex = 0;
            // 
            // BrowseDraftContentFile_Btn
            // 
            BrowseDraftContentFile_Btn.Dock = DockStyle.Right;
            BrowseDraftContentFile_Btn.Location = new Point(1469, 0);
            BrowseDraftContentFile_Btn.Margin = new Padding(10, 0, 0, 0);
            BrowseDraftContentFile_Btn.Name = "BrowseDraftContentFile_Btn";
            BrowseDraftContentFile_Btn.Size = new Size(112, 34);
            BrowseDraftContentFile_Btn.TabIndex = 1;
            BrowseDraftContentFile_Btn.Text = "Browse";
            BrowseDraftContentFile_Btn.UseVisualStyleBackColor = true;
            BrowseDraftContentFile_Btn.Click += BrowseDraftContentFile_Btn_Click;
            // 
            // EnableMinimizeSubtitle_Checkbox
            // 
            EnableMinimizeSubtitle_Checkbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EnableMinimizeSubtitle_Checkbox.AutoSize = true;
            EnableMinimizeSubtitle_Checkbox.Enabled = false;
            EnableMinimizeSubtitle_Checkbox.Location = new Point(37, 843);
            EnableMinimizeSubtitle_Checkbox.Name = "EnableMinimizeSubtitle_Checkbox";
            EnableMinimizeSubtitle_Checkbox.Size = new Size(186, 29);
            EnableMinimizeSubtitle_Checkbox.TabIndex = 2;
            EnableMinimizeSubtitle_Checkbox.Text = "Cleanup Dialogues";
            EnableMinimizeSubtitle_Checkbox.UseVisualStyleBackColor = true;
            // 
            // DialoguesTable
            // 
            DialoguesTable.AllowUserToAddRows = false;
            DialoguesTable.AllowUserToDeleteRows = false;
            DialoguesTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DialoguesTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DialoguesTable.BackgroundColor = SystemColors.ControlLightLight;
            DialoguesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DialoguesTable.Location = new Point(37, 76);
            DialoguesTable.Name = "DialoguesTable";
            DialoguesTable.ReadOnly = true;
            DialoguesTable.RowHeadersWidth = 62;
            DialoguesTable.Size = new Size(1581, 756);
            DialoguesTable.TabIndex = 3;
            // 
            // ExportSrt_Btn
            // 
            ExportSrt_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExportSrt_Btn.Enabled = false;
            ExportSrt_Btn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExportSrt_Btn.Location = new Point(375, 880);
            ExportSrt_Btn.Name = "ExportSrt_Btn";
            ExportSrt_Btn.Size = new Size(906, 55);
            ExportSrt_Btn.TabIndex = 4;
            ExportSrt_Btn.Text = "Export";
            ExportSrt_Btn.UseCompatibleTextRendering = true;
            ExportSrt_Btn.UseVisualStyleBackColor = true;
            ExportSrt_Btn.Click += ExportSrt_Btn_Click;
            // 
            // TranslateBtn
            // 
            TranslateBtn.Dock = DockStyle.Right;
            TranslateBtn.Location = new Point(1338, 0);
            TranslateBtn.Margin = new Padding(0, 0, 10, 0);
            TranslateBtn.Name = "TranslateBtn";
            TranslateBtn.Size = new Size(131, 34);
            TranslateBtn.TabIndex = 2;
            TranslateBtn.Text = "Translate";
            TranslateBtn.UseVisualStyleBackColor = true;
            TranslateBtn.Visible = false;
            TranslateBtn.Click += TranslateBtn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(TranslateBtn);
            panel1.Controls.Add(SubtitleFilePath_TextBox);
            panel1.Controls.Add(BrowseDraftContentFile_Btn);
            panel1.Location = new Point(37, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(1581, 34);
            panel1.TabIndex = 6;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1655, 965);
            Controls.Add(panel1);
            Controls.Add(ExportSrt_Btn);
            Controls.Add(DialoguesTable);
            Controls.Add(EnableMinimizeSubtitle_Checkbox);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CapLingo Lite";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)DialoguesTable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SubtitleFilePath_TextBox;
        private Button BrowseDraftContentFile_Btn;
        private CheckBox EnableMinimizeSubtitle_Checkbox;
        private DataGridView DialoguesTable;
        private Button ExportSrt_Btn;
        private Button TranslateBtn;
        private Panel panel1;
    }
}
