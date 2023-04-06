using BridgePattern.Model.Class.Weapon;
using BridgePattern.Model.Interface;
using BridgePattern.Realization.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Model.Class.Chars
{
    internal class Org : IPlayable
    {
        public int CritDamage { get; set; }
        public int Strength { get; set; }
        public IWeapon Weapon { get; set; } = new Sword() { WeaponName = "Меч новичка" };
        public string Name { get; set; }
        public int HP { get; set; }

        public void Beat(ICharacther characther)
        {
            Console.WriteLine(Name + "Бьет " + characther.Name);
        }

        public void Run()
        {
            Console.WriteLine(Name + " бежит ");
        }

        public void Stay()
        {
            Console.WriteLine(Name + " стоит в AFK ");
        }
        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
            Console.WriteLine("Вы дали " + Name + " " + weapon.WeaponName);
        }
        public void UseUlt()
        {
            Console.WriteLine(Name + " использует ультимейт ");
        }
        public void Die()
        {
            Console.WriteLine(Name + " умер ");
        }
        public override string ToString()
        {
            return $"{Name} {Strength} {HP} {Weapon.WeaponName}";
        }
    }
}
