namespace CapLingo_Lite
{
    partial class TranslationSettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TargetLanguage_ComboBox = new ComboBox();
            label1 = new Label();
            Start_Btn = new Button();
            LogTextBox = new RichTextBox();
            GeminiApiKey_TextBox = new TextBox();
            label2 = new Label();
            ValidateApiKey_Btn = new Button();
            SuspendLayout();
            // 
            // TargetLanguage_ComboBox
            // 
            TargetLanguage_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TargetLanguage_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TargetLanguage_ComboBox.FormattingEnabled = true;
            TargetLanguage_ComboBox.Location = new Point(18, 126);
            TargetLanguage_ComboBox.Name = "TargetLanguage_ComboBox";
            TargetLanguage_ComboBox.Size = new Size(724, 33);
            TargetLanguage_ComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 95);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 1;
            label1.Text = "Target Language";
            // 
            // Start_Btn
            // 
            Start_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Start_Btn.Enabled = false;
            Start_Btn.Location = new Point(282, 502);
            Start_Btn.Name = "Start_Btn";
            Start_Btn.Size = new Size(194, 47);
            Start_Btn.TabIndex = 2;
            Start_Btn.Text = "Start";
            Start_Btn.UseVisualStyleBackColor = true;
            Start_Btn.Click += Start_Btn_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogTextBox.BackColor = SystemColors.ControlLightLight;
            LogTextBox.BorderStyle = BorderStyle.None;
            LogTextBox.Location = new Point(18, 174);
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(724, 314);
            LogTextBox.TabIndex = 3;
            LogTextBox.Text = "";
            // 
            // GeminiApiKey_TextBox
            // 
            GeminiApiKey_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GeminiApiKey_TextBox.Location = new Point(18, 46);
            GeminiApiKey_TextBox.Name = "GeminiApiKey_TextBox";
            GeminiApiKey_TextBox.PlaceholderText = "AIzaSy...";
            GeminiApiKey_TextBox.Size = new Size(585, 31);
            GeminiApiKey_TextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(18, 13);
            label2.Name = "label2";
            label2.Size = new Size(132, 25);
            label2.TabIndex = 5;
            label2.Text = "Gemini API Key";
            // 
            // ValidateApiKey_Btn
            // 
            ValidateApiKey_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ValidateApiKey_Btn.Location = new Point(609, 44);
            ValidateApiKey_Btn.Name = "ValidateApiKey_Btn";
            ValidateApiKey_Btn.Size = new Size(133, 34);
            ValidateApiKey_Btn.TabIndex = 6;
            ValidateApiKey_Btn.Text = "Validate";
            ValidateApiKey_Btn.UseVisualStyleBackColor = true;
            ValidateApiKey_Btn.Click += ValidateApiKey_Btn_Click;
            // 
            // TranslationSettingsWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 561);
            Controls.Add(ValidateApiKey_Btn);
            Controls.Add(label2);
            Controls.Add(GeminiApiKey_TextBox);
            Controls.Add(LogTextBox);
            Controls.Add(Start_Btn);
            Controls.Add(label1);
            Controls.Add(TargetLanguage_ComboBox);
            Name = "TranslationSettingsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Translation Settings";
            Load += TranslationSettingsWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TargetLanguage_ComboBox;
        private Label label1;
        private Button Start_Btn;
        private RichTextBox LogTextBox;
        private TextBox GeminiApiKey_TextBox;
        private Label label2;
        private Button ValidateApiKey_Btn;
    }
}