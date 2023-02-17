using AddPersons.Model;
using AddPersons.Presenter;
using AddPersons.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace AddPersons
{
    public partial class MainView : Form
    {
        private PersonModel personModel = new();
        private PersonPresenter personPresenter;
        public Person person = new();
        public MainView()
        {
            InitializeComponent();

            personPresenter = new PersonPresenter(personModel,this);
            personModel = personPresenter.DeserializeFromFile<PersonModel>("AllPersons.json");

            if (personModel != null)
            {
                foreach (var item in personModel.ListofPeopel)
                {
                    PeoplesListBox.Items.Add(item);
                }
            }
           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            person.Name = nameTextBox.Text;
            person.Surname = surnameTextBox.Text;
            person.Age = Convert.ToInt32(ageTextBox.Text);
            

            try
            {
                personModel = personPresenter.AddPerson(person); 

                PeoplesListBox.Items.Add(person);

                nameTextBox.Clear();
                surnameTextBox.Clear();
                ageTextBox.Clear();

                person = new();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void avaButton_Click(object sender, EventArgs e) => person.AvaPath = personPresenter.AvaChoice(person);
        

        private void redactButton_Click(object sender, EventArgs e)
        {
            RedactView redactView = new RedactView(personPresenter, personModel.ListofPeopel[PeoplesListBox.SelectedIndex]);
            redactView.ShowDialog();

            personPresenter = new(personModel, this);
            personPresenter.RedactList(personModel.ListofPeopel[PeoplesListBox.SelectedIndex], PeoplesListBox.SelectedIndex);

            PeoplesListBox.Items.Clear();

            foreach (var item in personModel.ListofPeopel)
                PeoplesListBox.Items.Add(item);

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            personPresenter = new(personModel, this);
            personPresenter.DeletePerson(personModel.ListofPeopel[PeoplesListBox.SelectedIndex], PeoplesListBox.SelectedIndex);
            PeoplesListBox.Items.RemoveAt(PeoplesListBox.SelectedIndex);
        }
    }
}
