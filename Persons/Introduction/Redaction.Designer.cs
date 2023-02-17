namespace Introduction
{
    partial class Redaction
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
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RedactLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.AvaLabel = new System.Windows.Forms.Label();
            this.SurnametextBox = new System.Windows.Forms.TextBox();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.AgetextBox = new System.Windows.Forms.TextBox();
            this.Avabutton = new System.Windows.Forms.Button();
            this.AvapictureBox = new System.Windows.Forms.PictureBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.RedactLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvapictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog2
            // 
            this.colorDialog2.Color = System.Drawing.Color.Coral;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // RedactLayoutPanel
            // 
            this.RedactLayoutPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.RedactLayoutPanel.ColumnCount = 3;
            this.RedactLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RedactLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.RedactLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.RedactLayoutPanel.Controls.Add(this.NameLabel, 0, 0);
            this.RedactLayoutPanel.Controls.Add(this.SurnameLabel, 0, 1);
            this.RedactLayoutPanel.Controls.Add(this.AgeLabel, 0, 2);
            this.RedactLayoutPanel.Controls.Add(this.AvaLabel, 0, 3);
            this.RedactLayoutPanel.Controls.Add(this.SurnametextBox, 1, 1);
            this.RedactLayoutPanel.Controls.Add(this.NametextBox, 1, 0);
            this.RedactLayoutPanel.Controls.Add(this.AgetextBox, 1, 2);
            this.RedactLayoutPanel.Controls.Add(this.Avabutton, 1, 3);
            this.RedactLayoutPanel.Controls.Add(this.AvapictureBox, 2, 0);
            this.RedactLayoutPanel.Controls.Add(this.OKbutton, 0, 4);
            this.RedactLayoutPanel.Controls.Add(this.Cancelbutton, 1, 4);
            this.RedactLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedactLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.RedactLayoutPanel.Name = "RedactLayoutPanel";
            this.RedactLayoutPanel.RowCount = 6;
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.94595F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.05405F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RedactLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RedactLayoutPanel.Size = new System.Drawing.Size(595, 301);
            this.RedactLayoutPanel.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(38, 12);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(31, 15);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Имя";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(24, 56);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(58, 15);
            this.SurnameLabel.TabIndex = 2;
            this.SurnameLabel.Text = "Фамилия";
            // 
            // AgeLabel
            // 
            this.AgeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(28, 107);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(50, 15);
            this.AgeLabel.TabIndex = 3;
            this.AgeLabel.Text = "Возраст";
            this.AgeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvaLabel
            // 
            this.AvaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvaLabel.AutoSize = true;
            this.AvaLabel.Location = new System.Drawing.Point(25, 160);
            this.AvaLabel.Name = "AvaLabel";
            this.AvaLabel.Size = new System.Drawing.Size(57, 15);
            this.AvaLabel.TabIndex = 4;
            this.AvaLabel.Text = "Аватарка";
            // 
            // SurnametextBox
            // 
            this.SurnametextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SurnametextBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.SurnametextBox.Location = new System.Drawing.Point(110, 52);
            this.SurnametextBox.Name = "SurnametextBox";
            this.SurnametextBox.Size = new System.Drawing.Size(189, 23);
            this.SurnametextBox.TabIndex = 9;
            // 
            // NametextBox
            // 
            this.NametextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NametextBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.NametextBox.Location = new System.Drawing.Point(110, 8);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(189, 23);
            this.NametextBox.TabIndex = 8;
            // 
            // AgetextBox
            // 
            this.AgetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AgetextBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.AgetextBox.Location = new System.Drawing.Point(110, 103);
            this.AgetextBox.Name = "AgetextBox";
            this.AgetextBox.Size = new System.Drawing.Size(189, 23);
            this.AgetextBox.TabIndex = 10;
            // 
            // Avabutton
            // 
            this.Avabutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Avabutton.BackColor = System.Drawing.Color.LightCyan;
            this.Avabutton.Location = new System.Drawing.Point(110, 156);
            this.Avabutton.Name = "Avabutton";
            this.Avabutton.Size = new System.Drawing.Size(189, 23);
            this.Avabutton.TabIndex = 7;
            this.Avabutton.Text = "Выбрать новую аватарку";
            this.Avabutton.UseVisualStyleBackColor = false;
            this.Avabutton.Click += new System.EventHandler(this.Avabutton_Click);
            // 
            // AvapictureBox
            // 
            this.AvapictureBox.BackColor = System.Drawing.Color.DarkTurquoise;
            this.AvapictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvapictureBox.Location = new System.Drawing.Point(305, 3);
            this.AvapictureBox.Name = "AvapictureBox";
            this.RedactLayoutPanel.SetRowSpan(this.AvapictureBox, 6);
            this.AvapictureBox.Size = new System.Drawing.Size(287, 295);
            this.AvapictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvapictureBox.TabIndex = 11;
            this.AvapictureBox.TabStop = false;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKbutton.BackColor = System.Drawing.Color.Cyan;
            this.OKbutton.Location = new System.Drawing.Point(11, 219);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(85, 36);
            this.OKbutton.TabIndex = 5;
            this.OKbutton.Text = "Сохранить";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancelbutton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Cancelbutton.Location = new System.Drawing.Point(159, 219);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(90, 35);
            this.Cancelbutton.TabIndex = 6;
            this.Cancelbutton.Text = "Отменить";
            this.Cancelbutton.UseVisualStyleBackColor = false;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // Redaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 301);
            this.Controls.Add(this.RedactLayoutPanel);
            this.Name = "Redaction";
            this.Text = "Redaction";
            this.RedactLayoutPanel.ResumeLayout(false);
            this.RedactLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvapictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ColorDialog colorDialog1;
        private ColorDialog colorDialog2;
        private ContextMenuStrip contextMenuStrip1;
        private TableLayoutPanel RedactLayoutPanel;
        private Label NameLabel;
        private Label SurnameLabel;
        private Label AgeLabel;
        private Label AvaLabel;
        private Button Avabutton;
        private TextBox NametextBox;
        private TextBox SurnametextBox;
        private TextBox AgetextBox;
        private PictureBox AvapictureBox;
        private Button OKbutton;
        private Button Cancelbutton;
    }
}