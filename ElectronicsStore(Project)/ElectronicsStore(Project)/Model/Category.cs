using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Category
    {
        public string CategoryName {get;set;}
        public string Description { get; set; }
        public string IconPath { get; set; }   

        public override string ToString() => CategoryName;
        

    }

}
