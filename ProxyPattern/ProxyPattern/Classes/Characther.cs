using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProxyPattern.Classes.Weapon;

namespace ProxyPattern.Classes
{
    public class Characther
    {
        public string Name { get; set; } 
        public string Weapon { get; set; } 
        public int HP { get; set; } 
        public override string ToString()
        {
            return Name + " " +  HP + " " + Weapon;  
        }
    }
}
