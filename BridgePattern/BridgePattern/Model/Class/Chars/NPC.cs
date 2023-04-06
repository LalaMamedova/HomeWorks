using BridgePattern.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Model.Class.Chars
{
    internal class NPC : ICharacther
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public void Run()
        {
            Console.WriteLine("НПС " + Name + " Бежит");
        }

        public void Stay()
        {
            Console.WriteLine("НПС " + Name + " Стоит");
        }
        public void Die()
        {
            Console.WriteLine(Name + " умер ");
        }
        public override string ToString()
        {
            return Name + " " + HP;
        }
    }
}
