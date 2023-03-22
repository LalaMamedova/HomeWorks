using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdminPanel.Model
{
    public class Category 
    {
        private string? categoryName;
       
        public string? CategoryName
        {
            get => categoryName;

            set
            {
                Regex nameReg = new("[A-Za-z А-Яа-я 0-9]");

                if (nameReg.IsMatch(value)) 
                {
                    categoryName = value;
                    
                }
                else
                    throw new ArgumentException("В названии есть недопустимые сиволы");
            }
        }
        public string? Description { get; set; }

        public string? IconPath {get;set;}

        public override string ToString() => CategoryName;


    }

}
