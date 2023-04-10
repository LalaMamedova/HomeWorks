using Git_Marge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git_Marge.Realization
{
    public class CharacterRealization
    {
        public Character CreateCharacther(string name)
        {
            Character character = new Character() { HP = 200, Name = name};
            return character;
        }
    }
}
