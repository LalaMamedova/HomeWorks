using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introduction
{
    public partial class Redaction : Form
    {
        public List<Person> ListOfPerson { get; set; } = new();
     
        private int personindex;
   
        public Redaction()
        {
            InitializeComponent();
        }
     

        public Redaction(Person person)
        {
            InitializeComponent();

            NametextBox.Text = person.Name;
            SurnametextBox.Text = person.Surname;
            AgetextBox.Text = person.Age.ToString();
            AvapictureBox.Image = Image.FromFile(person.ImagePath);
            ListOfPerson[personindex].ImagePath = person.ImagePath;
           
        }

     
        public Redaction(List<Person> persons, int index)
        {
            InitializeComponent();
            ListOfPerson = persons;
            personindex = index;

            NametextBox.Text = persons[index].Name;
            SurnametextBox.Text = persons[index].Surname;
            AgetextBox.Text = persons[index].Age.ToString();
            AvapictureBox.Image = Image.FromFile(persons[index].ImagePath);

        }

        private void Avabutton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ListOfPerson[personindex].ImagePath = dialog.FileName;
            }
            AvapictureBox.Image = Image.FromFile(ListOfPerson[personindex].ImagePath);
        }
        
    
        private void OKbutton_Click(object sender, EventArgs e)
        {
            ListOfPerson[personindex].Name = NametextBox.Text;
            ListOfPerson[personindex].Surname = SurnametextBox.Text;
            ListOfPerson[personindex].Age = Convert.ToInt32(AgetextBox.Text);
           
            this.Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e) => this.Close();

       
    }
}
