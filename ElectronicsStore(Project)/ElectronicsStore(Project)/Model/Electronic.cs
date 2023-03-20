using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Electronic
    {
        public string? Name { get; set; }
        public string? Category { get; set; }

        public string? ImgPath { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public int CategoryIndex { get; set; }
        public float Price{ get; set; }
        public int Count{ get;set;}
        public int ID { get; set; }
        public string StrPrice { get => Price.ToString() + "  ₼ "; }
        public Electronic(string name, string category, string? imgPath, int count, float price)
        {
            Name = name;
            Category = category;
            ImgPath = imgPath;
            Count = count;
            Price = price;
        }
        public Electronic()
        {
            
        }

       

        public override string ToString()
        {
            return Name + " " + Category;
        }
    }
}
