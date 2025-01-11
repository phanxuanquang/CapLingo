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
            DraftContentFilePath_TextBox = new TextBox();
            BrowseDraftContentFile_Btn = new Button();
            EnableMinimizeSubtitle_Checkbox = new CheckBox();
            DialoguesTable = new DataGridView();
            ExportSrt_Btn = new Button();
            ((System.ComponentModel.ISupportInitialize)DialoguesTable).BeginInit();
            SuspendLayout();
            // 
            // DraftContentFilePath_TextBox
            // 
            DraftContentFilePath_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DraftContentFilePath_TextBox.Location = new Point(37, 36);
            DraftContentFilePath_TextBox.Name = "DraftContentFilePath_TextBox";
            DraftContentFilePath_TextBox.PlaceholderText = "C:\\Users\\user\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
            DraftContentFilePath_TextBox.ReadOnly = true;
            DraftContentFilePath_TextBox.Size = new Size(1450, 31);
            DraftContentFilePath_TextBox.TabIndex = 0;
            // 
            // BrowseDraftContentFile_Btn
            // 
            BrowseDraftContentFile_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseDraftContentFile_Btn.Location = new Point(1493, 34);
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
            EnableMinimizeSubtitle_Checkbox.Location = new Point(37, 848);
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
            DialoguesTable.BackgroundColor = SystemColors.ButtonFace;
            DialoguesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DialoguesTable.Location = new Point(37, 83);
            DialoguesTable.Name = "DialoguesTable";
            DialoguesTable.ReadOnly = true;
            DialoguesTable.RowHeadersWidth = 62;
            DialoguesTable.Size = new Size(1568, 754);
            DialoguesTable.TabIndex = 3;
            // 
            // ExportSrt_Btn
            // 
            ExportSrt_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExportSrt_Btn.Enabled = false;
            ExportSrt_Btn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExportSrt_Btn.Location = new Point(507, 885);
            ExportSrt_Btn.Name = "ExportSrt_Btn";
            ExportSrt_Btn.Size = new Size(629, 55);
            ExportSrt_Btn.TabIndex = 4;
            ExportSrt_Btn.Text = "Export";
            ExportSrt_Btn.UseCompatibleTextRendering = true;
            ExportSrt_Btn.UseVisualStyleBackColor = true;
            ExportSrt_Btn.Click += ExportSrt_Btn_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1642, 970);
            Controls.Add(ExportSrt_Btn);
            Controls.Add(DialoguesTable);
            Controls.Add(EnableMinimizeSubtitle_Checkbox);
            Controls.Add(BrowseDraftContentFile_Btn);
            Controls.Add(DraftContentFilePath_TextBox);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)DialoguesTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DraftContentFilePath_TextBox;
        private Button BrowseDraftContentFile_Btn;
        private CheckBox EnableMinimizeSubtitle_Checkbox;
        private DataGridView DialoguesTable;
        private Button ExportSrt_Btn;
    }
}
