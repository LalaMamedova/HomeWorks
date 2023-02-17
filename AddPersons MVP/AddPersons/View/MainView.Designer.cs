namespace AddPersons
{
    partial class MainView
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PeoplesListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.redactButton = new System.Windows.Forms.Button();
            this.AvaLabel = new System.Windows.Forms.Label();
            this.avaButton = new System.Windows.Forms.Button();
            this.ageLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.01351F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.98649F));
            this.tableLayoutPanel2.Controls.Add(this.PeoplesListBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.redactButton, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(464, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.99363F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 471);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // PeoplesListBox
            // 
            this.PeoplesListBox.BackColor = System.Drawing.Color.LightGreen;
            this.tableLayoutPanel2.SetColumnSpan(this.PeoplesListBox, 2);
            this.PeoplesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PeoplesListBox.FormattingEnabled = true;
            this.PeoplesListBox.ItemHeight = 15;
            this.PeoplesListBox.Location = new System.Drawing.Point(3, 3);
            this.PeoplesListBox.Name = "PeoplesListBox";
            this.PeoplesListBox.Size = new System.Drawing.Size(290, 429);
            this.PeoplesListBox.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Aquamarine;
            this.DeleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteButton.Location = new System.Drawing.Point(153, 438);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(140, 30);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // redactButton
            // 
            this.redactButton.BackColor = System.Drawing.Color.Aquamarine;
            this.redactButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redactButton.Location = new System.Drawing.Point(3, 438);
            this.redactButton.Name = "redactButton";
            this.redactButton.Size = new System.Drawing.Size(144, 30);
            this.redactButton.TabIndex = 2;
            this.redactButton.Text = "Редактировать";
            this.redactButton.UseVisualStyleBackColor = false;
            this.redactButton.Click += new System.EventHandler(this.redactButton_Click);
            // 
            // AvaLabel
            // 
            this.AvaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvaLabel.AutoSize = true;
            this.AvaLabel.Location = new System.Drawing.Point(122, 375);
            this.AvaLabel.Name = "AvaLabel";
            this.AvaLabel.Size = new System.Drawing.Size(57, 15);
            this.AvaLabel.TabIndex = 4;
            this.AvaLabel.Text = "Аватарка";
            // 
            // avaButton
            // 
            this.avaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.avaButton.BackColor = System.Drawing.Color.Aquamarine;
            this.avaButton.Location = new System.Drawing.Point(252, 371);
            this.avaButton.Name = "avaButton";
            this.avaButton.Size = new System.Drawing.Size(207, 23);
            this.avaButton.TabIndex = 0;
            this.avaButton.Text = "Выбрать";
            this.avaButton.UseVisualStyleBackColor = false;
            this.avaButton.Click += new System.EventHandler(this.avaButton_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(125, 277);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(50, 15);
            this.ageLabel.TabIndex = 3;
            this.ageLabel.Text = "Возраст";
            // 
            // surnameLabel
            // 
            this.surnameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(121, 157);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(58, 15);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Фамилия";
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(135, 44);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(31, 15);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Имя";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.88353F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.11646F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ageLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.avaButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.AvaLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.surnameTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ageTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.58139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.41861F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 471);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 5);
            this.panel1.Size = new System.Drawing.Size(46, 465);
            this.panel1.TabIndex = 5;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(252, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 23);
            this.nameTextBox.TabIndex = 6;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.surnameTextBox.Location = new System.Drawing.Point(252, 153);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(207, 23);
            this.surnameTextBox.TabIndex = 7;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ageTextBox.Location = new System.Drawing.Point(252, 273);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(207, 23);
            this.ageTextBox.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(222)))), ((int)(((byte)(164)))));
            this.tableLayoutPanel1.SetColumnSpan(this.addButton, 2);
            this.addButton.Location = new System.Drawing.Point(55, 425);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(404, 43);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 471);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainView";
            this.Text = "WindowsView";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private Button redactButton;
        private Button DeleteButton;
        private ListBox PeoplesListBox;
        private Label AvaLabel;
        private Button avaButton;
        private Label ageLabel;
        private Label surnameLabel;
        private Label NameLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private TextBox ageTextBox;
        private Button addButton;
    }
}