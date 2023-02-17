namespace AddPersons.View
{
    partial class RedactView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.avaButton = new System.Windows.Forms.Button();
            this.AvaLabel = new System.Windows.Forms.Label();
            this.avaBox = new System.Windows.Forms.PictureBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(57)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.surnameTextBox);
            this.panel1.Controls.Add(this.ageTextBox);
            this.panel1.Controls.Add(this.avaButton);
            this.panel1.Controls.Add(this.AvaLabel);
            this.panel1.Controls.Add(this.avaBox);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.surnameLabel);
            this.panel1.Controls.Add(this.ageLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 357);
            this.panel1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.okButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.okButton.Location = new System.Drawing.Point(146, 322);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(99, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(246, 45);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(125, 23);
            this.nameTextBox.TabIndex = 13;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(246, 120);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(125, 23);
            this.surnameTextBox.TabIndex = 14;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(246, 199);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(125, 23);
            this.ageTextBox.TabIndex = 15;
            // 
            // avaButton
            // 
            this.avaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.avaButton.BackColor = System.Drawing.Color.Brown;
            this.avaButton.ForeColor = System.Drawing.Color.White;
            this.avaButton.Location = new System.Drawing.Point(246, 267);
            this.avaButton.Name = "avaButton";
            this.avaButton.Size = new System.Drawing.Size(115, 23);
            this.avaButton.TabIndex = 11;
            this.avaButton.Text = "Выбрать";
            this.avaButton.UseVisualStyleBackColor = false;
            this.avaButton.Click += new System.EventHandler(this.avaButton_Click);
            // 
            // AvaLabel
            // 
            this.AvaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvaLabel.AutoSize = true;
            this.AvaLabel.ForeColor = System.Drawing.Color.White;
            this.AvaLabel.Location = new System.Drawing.Point(25, 267);
            this.AvaLabel.Name = "AvaLabel";
            this.AvaLabel.Size = new System.Drawing.Size(57, 15);
            this.AvaLabel.TabIndex = 12;
            this.AvaLabel.Text = "Аватарка";
            // 
            // avaBox
            // 
            this.avaBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(21)))), ((int)(((byte)(17)))));
            this.avaBox.Location = new System.Drawing.Point(396, 30);
            this.avaBox.Name = "avaBox";
            this.avaBox.Size = new System.Drawing.Size(206, 327);
            this.avaBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avaBox.TabIndex = 10;
            this.avaBox.TabStop = false;
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NameLabel.Location = new System.Drawing.Point(40, 48);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(31, 15);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Имя";
            // 
            // surnameLabel
            // 
            this.surnameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.surnameLabel.Location = new System.Drawing.Point(32, 128);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(58, 15);
            this.surnameLabel.TabIndex = 5;
            this.surnameLabel.Text = "Фамилия";
            // 
            // ageLabel
            // 
            this.ageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ageLabel.AutoSize = true;
            this.ageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ageLabel.Location = new System.Drawing.Point(32, 202);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(50, 15);
            this.ageLabel.TabIndex = 6;
            this.ageLabel.Text = "Возраст";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 33);
            this.panel2.TabIndex = 0;
            // 
            // RedactView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 357);
            this.Controls.Add(this.panel1);
            this.Name = "RedactView";
            this.Text = "RedactView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avaBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox avaBox;
        private Label NameLabel;
        private Label surnameLabel;
        private Label ageLabel;
        private Button avaButton;
        private Label AvaLabel;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private TextBox ageTextBox;
        private Button okButton;
    }
}