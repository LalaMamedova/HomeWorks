using Introduction.Files;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Introduction
{
    public partial class Persons : Form, MySerializable
    {
        public Person Person { get; set; } = new();
        public List<Person> people { get; set; } = new();

        public Persons()
        {
            InitializeComponent();
            LoadFromFile();
        }
        private void Reset() { 

            FileStream sw = new("PersonList.json", FileMode.Truncate);
            sw.Close();
        }
        
        private void addButton_Click(object sender, EventArgs e)
        {
            Regex re = new("^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$");
            Regex re2 = new("^[1-9][0-9]*");

            if (re.IsMatch(nameTextBox.Text) && re.IsMatch(surnameTextBox.Text) && re2.IsMatch(ageTextBox.Text))
            {
                Person.Name = nameTextBox.Text;
                Person.Surname = surnameTextBox.Text;
                Person.Age = Convert.ToInt32(ageTextBox.Text);

                peopleListBox.Items.Add(Person);
                people.Add(Person);
             
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                ageTextBox.Text = "";

                var result = JsonConvert.SerializeObject(people);
                FileService.WriteToFile(result, "PersonList.json", FileMode.OpenOrCreate);
            }
            else
                MessageBox.Show("Enter valid info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Person = new();
        }

        private void peopleListBox_DoubleClick(object sender, EventArgs e)
        {
            InfoForm form = new(people, peopleListBox.SelectedIndex);
            form.ShowDialog();
        }

        private void imgButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Person.ImagePath = dialog.FileName;
            }
        }

        private void Redactbutton_Click(object sender, EventArgs e)
        {
            Redaction redaction = new Redaction(people, peopleListBox.SelectedIndex);
            redaction.ShowDialog();

            peopleListBox.Items[peopleListBox.SelectedIndex] = redaction.ListOfPerson[peopleListBox.SelectedIndex];
            people[peopleListBox.SelectedIndex] = redaction.ListOfPerson[peopleListBox.SelectedIndex];

            Reset();

            var result = JsonConvert.SerializeObject(people);
            FileService.WriteToFile(result, "PersonList.json", FileMode.Open);
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            people.RemoveAt(peopleListBox.SelectedIndex);
            peopleListBox.Items.RemoveAt(peopleListBox.SelectedIndex);

            Reset();

            var result = JsonConvert.SerializeObject(people);
            FileService.WriteToFile(result, "PersonList.json", FileMode.OpenOrCreate);
        }
        private void LoadFromFile()
        {
            string? json = FileService.ReadFromFile("PersonList.json", FileMode.OpenOrCreate);

            if (json != null)
                people = JsonConvert.DeserializeObject<List<Person>>(json);

            else
                MessageBox.Show("Œÿ»¡ ¿");

            if (people != null)
            {
                foreach (var item in people)
                {
                    peopleListBox.Items.Add(item);
                }
            }
            else
                people = new();

        }
       
    }
}