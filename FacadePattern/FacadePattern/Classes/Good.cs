using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public  class Good
    {
        public string Name { get; set; }    
        public int Count { get; set; }
        public float Price { get; set; }

        public Good() { }
        public Good(string name, int count, float price) 
        {
            Name = name;
            Count = count;
            Price = price;

        }

        public override string ToString()
        {
            return Name  + "   " + Price + "   " + Count;
        }
    }
}
