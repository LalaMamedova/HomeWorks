using AddPersons.Model;
using AddPersons.Service.Clases;
using AddPersons.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AddPersons.Presenter
{
    public class PersonPresenter
    {
        private MainView mainView;
        private RedactView redactView;

        private PersonModel personModel = new();
        public Person newPerson = new();

        public PersonPresenter(PersonModel personModel, RedactView redactView)
        {
            this.redactView = redactView;
            this.personModel = personModel;
        }

        public PersonPresenter(PersonModel personModel, MainView Mainview)
        {
            this.mainView = Mainview;
            this.personModel = personModel;
        }
     
        public T DeserializeFromFile<T>(string? path)
        {
            string? json = Files.ReadFromFile(path);
            try
            {
                if (json != null)
                    return SerializeConvert.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return SerializeConvert.Deserialize<T>(json);
        }
        public void SerializeToFile<T>(string? path, T obj)
        {
            string? json = SerializeConvert.Serialize<T>(obj);
            Files.WriteToFile(path, json);
        }

    
        public PersonModel AddPerson(Person? person)
        {
            Regex stringCheck = new("[A-Za-z]");
            Regex intCheck = new("[1-9 0-9]");

            if (stringCheck.IsMatch(person.Name) && 
                stringCheck.IsMatch(person.Surname) && 
                intCheck.IsMatch(person.Age.ToString()))
            {
                
                personModel.ListofPeopel.Add(person);
                SerializeToFile<PersonModel>("AllPersons.json",personModel);
                return personModel;
            }

            else
            {
                throw new Exception("Введите все данные правильно");
            }
            
        }

        public Person RedactPerson(Person person)
        {
            newPerson = person;
            return newPerson;
        }

        public List<Person> RedactList(Person person, int index)
        {
            RedactPerson(person);
           
            personModel.ListofPeopel[index] = newPerson;
            using FileStream fileStream = new("AllPersons.json", FileMode.Truncate);
            fileStream.Close();

            SerializeToFile<PersonModel>("AllPersons.json", personModel);

            return personModel.ListofPeopel;
        }

        public string AvaChoice(Person person)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.jfif";
            dialog.Title = "Выберите аватарку";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
                person.AvaPath = dialog.FileName;
            
            return person.AvaPath;
        }

        public List<Person> DeletePerson(Person person, int index)
        {
            if (personModel.ListofPeopel.Count == 1)
            {
                personModel.ListofPeopel.RemoveAt(0);
                using FileStream fileStream = new("AllPersons.json", FileMode.Truncate);
            }
            else
            {
                personModel.ListofPeopel.RemoveAt(index);
                using FileStream filestream = new("AllPersons.json", FileMode.Truncate);

                filestream.Close();
                SerializeToFile<PersonModel>("AllPersons.json", personModel);
            }

            return personModel.ListofPeopel;
        }
        
       
    }
}
