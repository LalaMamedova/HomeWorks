using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPersons.Model
{
    public class PersonModel
    {
        public List<Person> ListofPeopel { get; set; } = new();

        public PersonModel(params Person[] listofPeopel)
        {
            ListofPeopel.AddRange(listofPeopel);
        }

        public PersonModel() { }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in ListofPeopel)
            {
                stringBuilder.Append(item.ToString());
            }
            return stringBuilder.ToString();
        }
    }



    public class Person
    {
        private int age;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public int Age

        {
            get => age;
            set
            {
                if (value > 10 && value <= 90)
                    age = value;
                else
                    throw new Exception("Возраст должен быть выше 10 и меньше равно 90");
            }
        }
        public string? AvaPath { get; set; }
        public Person() { }
        public Person(string? surname, string? name, int age, string? avaPath)
        {
            Surname = surname;
            Name = name;
            Age = age;
            AvaPath = avaPath;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + Age.ToString();
        }
    }
}
