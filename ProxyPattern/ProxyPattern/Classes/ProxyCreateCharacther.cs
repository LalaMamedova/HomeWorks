using ProxyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProxyPattern.Classes.Weapon;

namespace ProxyPattern.Classes
{
    internal class ProxyCreateCharacther : ICreateCharacther
    {
        private List<Characther> MyCharacthersList = new();
        private CreateRealCharacther CreateRealCharacther = new();
        public Characther? Characther { get; set; }

        public Characther? CreateCharacther()
        {
            Characther =  CreateRealCharacther.CreateCharacther();

            if (!MyCharacthersList.Contains(Characther))
            {
                Console.WriteLine(Characther.Name + " был добавлен в список ваших персонажей");
                MyCharacthersList.Add(Characther);
                return Characther;
            }
            else
                Console.WriteLine(Characther + " уже существует");

            return null;
           
        }
    }
}
