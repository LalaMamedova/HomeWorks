using BridgePattern.Model.Class.Chars;
using BridgePattern.Model.Class.Weapon;
using BridgePattern.Model.Interface;
using BridgePattern.Realization.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Realization.Class
{
    internal class CreateWeapon:ICreateble
    {
        private IWeapon Weapon { get; set; }

        public IWeapon CreateNewWeapon()
        {
            Console.WriteLine("Введите тип оружия" +
               "\n1.Меч" +
               "\n2.Лук");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Weapon = new Sword();
                    break;
                case 2:
                    Weapon = new Bow();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Введите имя луку");
            Weapon.WeaponName = Console.ReadLine();

            Console.WriteLine("Введите базоваю атаку ");
            Weapon.BaseAtack = int.Parse(Console.ReadLine());

            return Weapon;
        }

 
    }
}
