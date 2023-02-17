using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume_Project
{
    public class Employee
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Education { get; set; }  
        public Employee(string name, string surName, string patronymic, string education)
        {
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
            Education = education;
        }
        public Employee() { }

        public override string ToString()
        {
            return $" Имя: {Name}\n Фамилия: {SurName}\n Отчество: {Patronymic}\n Образование: {Education}\n";
        }
    }
}
