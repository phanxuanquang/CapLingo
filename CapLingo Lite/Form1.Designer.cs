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
            textBox1 = new TextBox();
            button1 = new Button();
            checkBox1 = new CheckBox();
            dataGridView1 = new DataGridView();
            Index = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            EndTime = new DataGridViewTextBoxColumn();
            Dialogue = new DataGridViewTextBoxColumn();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(37, 36);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "C:\\Users\\user\\AppData\\Local\\CapCut\\User Data\\Projects\\com.lveditor.draft\\";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(1450, 31);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1493, 34);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(37, 848);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(256, 29);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Merge interrupted dialogue";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Index, StartTime, EndTime, Dialogue });
            dataGridView1.Location = new Point(37, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1568, 754);
            dataGridView1.TabIndex = 3;
            // 
            // Index
            // 
            Index.HeaderText = "Index";
            Index.MinimumWidth = 8;
            Index.Name = "Index";
            Index.ReadOnly = true;
            // 
            // StartTime
            // 
            StartTime.HeaderText = "Start";
            StartTime.MinimumWidth = 8;
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            EndTime.HeaderText = "End";
            EndTime.MinimumWidth = 8;
            EndTime.Name = "EndTime";
            EndTime.ReadOnly = true;
            // 
            // Dialogue
            // 
            Dialogue.HeaderText = "Dialogue";
            Dialogue.MinimumWidth = 8;
            Dialogue.Name = "Dialogue";
            Dialogue.ReadOnly = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(507, 885);
            button2.Name = "button2";
            button2.Size = new Size(629, 55);
            button2.TabIndex = 4;
            button2.Text = "Export";
            button2.UseCompatibleTextRendering = true;
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1642, 970);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private CheckBox checkBox1;
        private DataGridView dataGridView1;
        private Button button2;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private DataGridViewTextBoxColumn Dialogue;
    }
}
