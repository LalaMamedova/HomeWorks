namespace Resume_Project
{
    partial class Resume
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
            System.Windows.Forms.TextBox BiotextBox;
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FIOlabel = new System.Windows.Forms.Label();
            this.FIOtextBox = new System.Windows.Forms.TextBox();
            this.Explabel = new System.Windows.Forms.Label();
            this.Biolabel = new System.Windows.Forms.Label();
            this.ExptextBox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            BiotextBox = new System.Windows.Forms.TextBox();
            this.MainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLayoutPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Controls.Add(this.FIOlabel, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.FIOtextBox, 1, 0);
            this.MainLayoutPanel.Controls.Add(this.Explabel, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.Biolabel, 0, 2);
            this.MainLayoutPanel.Controls.Add(this.ExptextBox, 1, 1);
            this.MainLayoutPanel.Controls.Add(BiotextBox, 1, 2);
            this.MainLayoutPanel.Location = new System.Drawing.Point(137, 30);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 3;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.10714F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.89286F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(437, 334);
            this.MainLayoutPanel.TabIndex = 0;
            this.MainLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainLayoutPanel_Paint);
            // 
            // FIOlabel
            // 
            this.FIOlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FIOlabel.AutoSize = true;
            this.FIOlabel.Location = new System.Drawing.Point(3, 27);
            this.FIOlabel.Name = "FIOlabel";
            this.FIOlabel.Size = new System.Drawing.Size(212, 15);
            this.FIOlabel.TabIndex = 0;
            this.FIOlabel.Text = "ФИО";
            this.FIOlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FIOtextBox
            // 
            this.FIOtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FIOtextBox.BackColor = System.Drawing.Color.LightBlue;
            this.FIOtextBox.Location = new System.Drawing.Point(221, 16);
            this.FIOtextBox.Multiline = true;
            this.FIOtextBox.Name = "FIOtextBox";
            this.FIOtextBox.Size = new System.Drawing.Size(213, 36);
            this.FIOtextBox.TabIndex = 1;
            // 
            // Explabel
            // 
            this.Explabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Explabel.Location = new System.Drawing.Point(3, 93);
            this.Explabel.Name = "Explabel";
            this.Explabel.Size = new System.Drawing.Size(212, 23);
            this.Explabel.TabIndex = 2;
            this.Explabel.Text = "Образование";
            this.Explabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Biolabel
            // 
            this.Biolabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Biolabel.AutoSize = true;
            this.Biolabel.Location = new System.Drawing.Point(3, 230);
            this.Biolabel.Name = "Biolabel";
            this.Biolabel.Size = new System.Drawing.Size(212, 15);
            this.Biolabel.TabIndex = 3;
            this.Biolabel.Text = "Ваша Биография";
            this.Biolabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExptextBox
            // 
            this.ExptextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExptextBox.BackColor = System.Drawing.Color.SkyBlue;
            this.ExptextBox.Location = new System.Drawing.Point(221, 79);
            this.ExptextBox.Multiline = true;
            this.ExptextBox.Name = "ExptextBox";
            this.ExptextBox.Size = new System.Drawing.Size(213, 51);
            this.ExptextBox.TabIndex = 5;
            // 
            // BiotextBox
            // 
            BiotextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            BiotextBox.BackColor = System.Drawing.Color.LightSkyBlue;
            BiotextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            BiotextBox.Location = new System.Drawing.Point(221, 144);
            BiotextBox.Multiline = true;
            BiotextBox.Name = "BiotextBox";
            BiotextBox.Size = new System.Drawing.Size(213, 187);
            BiotextBox.TabIndex = 4;
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.SlateBlue;
            this.OKbutton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.OKbutton.Location = new System.Drawing.Point(66, 392);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(546, 40);
            this.OKbutton.TabIndex = 1;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Resume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(682, 460);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.MainLayoutPanel);
            this.Name = "Resume";
            this.Text = "Резюме";
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel MainLayoutPanel;
        private Label FIOlabel;
        private TextBox FIOtextBox;
        private Label Explabel;
        private Label Biolabel;
        private TextBox ExptextBox;
        private TextBox BiotextBox;
        private Button OKbutton;
    }
}