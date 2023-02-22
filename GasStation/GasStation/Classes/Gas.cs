using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GasStation.Classes
{
    //public enum Gases { A72, A92, A93}
    public class Gas
    {
        public float Price { get; set; }
        public float Value { get; set; }    
        public string GasName { get; set; }
        
        public Gas(string name, float price,float value)
        {
            GasName = name;
            Price = price;
            Value = value;
        }

        public Gas() 
        {
            
        }

        public override string ToString()
        {
            return GasName + Price.ToString() + Value.ToString();
        }

    }
}
