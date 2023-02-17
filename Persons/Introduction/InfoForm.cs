using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Introduction
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }
        public InfoForm(List<Person> peoples, int index)
        {
            InitializeComponent();

            nameLabel.Text = peoples[index].Name;
            surnameLabel.Text = peoples[index].Surname;
            ageLabel.Text = peoples[index].Age.ToString();
            pictureBox.Image = Image.FromFile(peoples[index].ImagePath);
            
        }
   

        
    }
}
