namespace Introduction
{
    partial class Persons
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Redactbutton = new System.Windows.Forms.Button();
            this.peopleListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.imgLabel = new System.Windows.Forms.Label();
            this.imgButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Deletebutton);
            this.panel1.Controls.Add(this.Redactbutton);
            this.panel1.Controls.Add(this.peopleListBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(469, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 378);
            this.panel1.TabIndex = 0;
            // 
            // Deletebutton
            // 
            this.Deletebutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Deletebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Deletebutton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Deletebutton.Location = new System.Drawing.Point(127, 355);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(130, 23);
            this.Deletebutton.TabIndex = 8;
            this.Deletebutton.Text = "Удалить";
            this.Deletebutton.UseVisualStyleBackColor = false;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // Redactbutton
            // 
            this.Redactbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Redactbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Redactbutton.Location = new System.Drawing.Point(0, 355);
            this.Redactbutton.Name = "Redactbutton";
            this.Redactbutton.Size = new System.Drawing.Size(129, 23);
            this.Redactbutton.TabIndex = 7;
            this.Redactbutton.Text = "Редактировать";
            this.Redactbutton.UseVisualStyleBackColor = false;
            this.Redactbutton.Click += new System.EventHandler(this.Redactbutton_Click);
            // 
            // peopleListBox
            // 
            this.peopleListBox.BackColor = System.Drawing.Color.Turquoise;
            this.peopleListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.peopleListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.peopleListBox.FormattingEnabled = true;
            this.peopleListBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.peopleListBox.ItemHeight = 15;
            this.peopleListBox.Location = new System.Drawing.Point(0, 0);
            this.peopleListBox.MultiColumn = true;
            this.peopleListBox.Name = "peopleListBox";
            this.peopleListBox.Size = new System.Drawing.Size(254, 360);
            this.peopleListBox.TabIndex = 0;
            this.peopleListBox.DoubleClick += new System.EventHandler(this.peopleListBox_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ageTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.imgLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.imgButton, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 378);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(101, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(31, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            // 
            // surnameLabel
            // 
            this.surnameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(88, 99);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(58, 15);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Фамилия";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.nameTextBox.Location = new System.Drawing.Point(237, 24);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(229, 23);
            this.nameTextBox.TabIndex = 2;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.surnameTextBox.Location = new System.Drawing.Point(237, 95);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(229, 23);
            this.surnameTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Aquamarine;
            this.tableLayoutPanel1.SetColumnSpan(this.addButton, 2);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(3, 278);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(463, 44);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Возраст";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ageTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.ageTextBox.Location = new System.Drawing.Point(237, 162);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(229, 23);
            this.ageTextBox.TabIndex = 6;
            // 
            // imgLabel
            // 
            this.imgLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgLabel.AutoSize = true;
            this.imgLabel.Location = new System.Drawing.Point(75, 232);
            this.imgLabel.Name = "imgLabel";
            this.imgLabel.Size = new System.Drawing.Size(83, 15);
            this.imgLabel.TabIndex = 7;
            this.imgLabel.Text = "Изображение";
            // 
            // imgButton
            // 
            this.imgButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgButton.BackColor = System.Drawing.Color.Aquamarine;
            this.imgButton.Location = new System.Drawing.Point(266, 221);
            this.imgButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imgButton.Name = "imgButton";
            this.imgButton.Size = new System.Drawing.Size(171, 37);
            this.imgButton.TabIndex = 8;
            this.imgButton.Text = "Выбрать изображение";
            this.imgButton.UseVisualStyleBackColor = false;
            this.imgButton.Click += new System.EventHandler(this.imgButton_Click);
            // 
            // Persons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(723, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Persons";
            this.Text = "Person";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox peopleListBox;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label nameLabel;
        private Label surnameLabel;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private Button addButton;
        private Label label1;
        private TextBox ageTextBox;
        private Label imgLabel;
        private Button imgButton;
        private Button Redactbutton;
        private Button Deletebutton;
    }
}