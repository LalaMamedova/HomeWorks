using BridgePattern.Model.Class.Chars;
using BridgePattern.Model.Interface;
using BridgePattern.Realization.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Realization.Class
{
    public class CreateChar: ICreateble
    {

        private IPlayable Characther;

        private ICharacther NPCCharacther;

        public IPlayable CreatePlayebleCharacther()
        {
            Console.WriteLine("Введите рассу персонажа" +
                "\n1.Эльф" +
                "\n2.Орк");

            int choice = int.Parse (Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Characther = new Elf();
                    break;
                case 2:
                    Characther = new Org();
                    break;

                default:
                    break;
            }

            Console.WriteLine("Введите имя персонажа");
            Characther.Name = Console.ReadLine();

            Console.WriteLine("Введите ХП персонажа");
            Characther.HP = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите силу атаки персонажа");
            Characther.Strength = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите крит урон персонажа");
            Characther.CritDamage = int.Parse(Console.ReadLine());

            return Characther;

        }


        public ICharacther CreateCharacther()
        {
            NPCCharacther = new NPC();

            Console.WriteLine("Введите имя персонажа");
            Characther.Name = Console.ReadLine();

            Console.WriteLine("Введите ХП персонажа");
            Characther.HP = int.Parse(Console.ReadLine());

            return NPCCharacther;

        }
    }
}
