namespace Download
{
    partial class Form1
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
            downloadList = new ListBox();
            downloadProgressBar = new ProgressBar();
            downloadButton = new Button();
            DescriptionTextBox = new TextBox();
            SuspendLayout();
            // 
            // downloadList
            // 
            downloadList.AllowDrop = true;
            downloadList.BackColor = Color.LightCoral;
            downloadList.FormattingEnabled = true;
            downloadList.IntegralHeight = false;
            downloadList.ItemHeight = 15;
            downloadList.Location = new Point(0, 35);
            downloadList.MultiColumn = true;
            downloadList.Name = "downloadList";
            downloadList.Size = new Size(467, 439);
            downloadList.TabIndex = 0;
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.BackColor = Color.FromArgb(255, 192, 255);
            downloadProgressBar.Location = new Point(0, 480);
            downloadProgressBar.Minimum = 1;
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(421, 23);
            downloadProgressBar.Step = 5;
            downloadProgressBar.TabIndex = 1;
            downloadProgressBar.Value = 1;
            // 
            // downloadButton
            // 
            downloadButton.BackColor = Color.FromArgb(255, 140, 184);
            downloadButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            downloadButton.Location = new Point(377, -3);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(216, 32);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Скачать";
            downloadButton.UseVisualStyleBackColor = false;
            downloadButton.Click += downloadButton_Click;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.BackColor = Color.FromArgb(255, 192, 192);
            DescriptionTextBox.Location = new Point(560, 35);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(298, 439);
            DescriptionTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(870, 505);
            Controls.Add(DescriptionTextBox);
            Controls.Add(downloadButton);
            Controls.Add(downloadProgressBar);
            Controls.Add(downloadList);
            Name = "Form1";
            Text = "Скачать(определннно не вирус)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox downloadList;
        private ProgressBar downloadProgressBar;
        private Button downloadButton;
        private TextBox DescriptionTextBox;
    }
}