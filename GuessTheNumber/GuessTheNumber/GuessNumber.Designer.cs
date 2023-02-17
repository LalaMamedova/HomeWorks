namespace GuessTheNumber
{
    partial class GuessNumber
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
            this.Guesslabel = new System.Windows.Forms.Label();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GuessTextBox = new System.Windows.Forms.MaskedTextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.MainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Guesslabel
            // 
            this.Guesslabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Guesslabel.AutoSize = true;
            this.MainLayoutPanel.SetColumnSpan(this.Guesslabel, 2);
            this.Guesslabel.Location = new System.Drawing.Point(3, 16);
            this.Guesslabel.Name = "Guesslabel";
            this.Guesslabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Guesslabel.Size = new System.Drawing.Size(371, 15);
            this.Guesslabel.TabIndex = 0;
            this.Guesslabel.Text = "Введиье число";
            this.Guesslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Guesslabel.DoubleClick += new System.EventHandler(this.Guesslabel_DoubleClick);
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.BackColor = System.Drawing.Color.Pink;
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.48186F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.51814F));
            this.MainLayoutPanel.Controls.Add(this.Guesslabel, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.GuessTextBox, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.OKbutton, 0, 2);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 4;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(377, 254);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // GuessTextBox
            // 
            this.GuessTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GuessTextBox.BackColor = System.Drawing.Color.Thistle;
            this.GuessTextBox.CausesValidation = false;
            this.MainLayoutPanel.SetColumnSpan(this.GuessTextBox, 2);
            this.GuessTextBox.Location = new System.Drawing.Point(145, 52);
            this.GuessTextBox.Name = "GuessTextBox";
            this.GuessTextBox.Size = new System.Drawing.Size(87, 23);
            this.GuessTextBox.TabIndex = 1;
            this.GuessTextBox.ValidatingType = typeof(int);
            this.GuessTextBox.DoubleClick += new System.EventHandler(this.GuessTextBox_DoubleClick);
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKbutton.BackColor = System.Drawing.Color.LightCoral;
            this.MainLayoutPanel.SetColumnSpan(this.OKbutton, 2);
            this.OKbutton.Location = new System.Drawing.Point(143, 85);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(91, 30);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // GuessNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(377, 254);
            this.Controls.Add(this.MainLayoutPanel);
            this.Name = "GuessNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Угадай число";
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label Guesslabel;
        private TableLayoutPanel MainLayoutPanel;
        private MaskedTextBox GuessTextBox;
        private Button OKbutton;
    }
}