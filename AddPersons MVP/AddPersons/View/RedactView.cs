using AddPersons.Model;
using AddPersons.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddPersons.View
{
    public partial class RedactView : Form
    {
        public Person redactPerson = new();
        private readonly PersonPresenter _personPresenter;
        public RedactView()
        {
            InitializeComponent();
        }

        public RedactView(PersonPresenter persenprestn, Person person)
        {
            InitializeComponent();
            redactPerson = person;
            _personPresenter = persenprestn;

            nameTextBox.Text = person.Name;
            surnameTextBox.Text = person.Surname;
            ageTextBox.Text = person.Age.ToString();
            avaBox.ImageLocation = person.AvaPath;
        }

        private void avaButton_Click(object sender, EventArgs e)
        {
            avaBox.ImageLocation = _personPresenter.AvaChoice(redactPerson);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            redactPerson.Name = nameTextBox.Text;
            redactPerson.Surname = surnameTextBox.Text;
            redactPerson.AvaPath = avaBox.ImageLocation;
            redactPerson.Age = Convert.ToInt32(ageTextBox.Text);

            _personPresenter.RedactPerson(redactPerson);
            this.Close();
        }
    }
}
