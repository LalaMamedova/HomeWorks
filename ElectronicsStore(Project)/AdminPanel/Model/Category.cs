using System;
using System.Collections.Generic;
using System.Linq;
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
                    categoryName = value;
                else
                    throw new ArgumentException("В названии есть недопустимые сиволы");
            } 
        }
        public string? Description { get; set; }
        public int Index { get; set; } 
        public static int CategoryID { get; set; } = 0;

        // public string? IconPath { get; set; }   

        public Category()
        {
            Index = CategoryID;
            CategoryID ++;
        }

        public Category(string? categoryName, string? description)
        {
            CategoryName = categoryName;
            Description = description;

            Index = CategoryID;
            CategoryID ++;
        }

        public override string ToString() => CategoryName;
        

    }

}
