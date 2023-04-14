using ProxyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Classes
{
    internal class CreateRealCharacther : ICreateCharacther
    {
        public Characther Characther { get; set; }
        public Weapon Weapon { get; set; } = new();

        public Characther? CreateCharacther()
        {
            Characther = new();

            Console.WriteLine("Введите имя персонажа");
            Characther.Name = Console.ReadLine();

            Console.WriteLine("Введите ХП персонажа");
            Characther.HP = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < Weapon.Weapons.Count; i++)
                Console.WriteLine($"{i+1} {Weapon.Weapons[i]}");
            
            Console.WriteLine("Выберите оружие персонажу");

            int choiceWeapon = Int32.Parse(Console.ReadLine());

            if (choiceWeapon < Weapon.Weapons.Count)
            {
                Characther.Weapon = Weapon.Weapons[choiceWeapon - 1];
            }
            return Characther;  
        }
    }
}
