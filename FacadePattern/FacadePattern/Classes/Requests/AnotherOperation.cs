using FacadePattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes.Requests
{
    public class AnotherOperation
    {
        public static int Choice()
        {
            Console.WriteLine("Выберите товар");
            return int.Parse(Console.ReadLine()) - 1;

        }

        public static Package? ClientGoodsChoice(Client client)
        {
            if (client.Goods.Count > 0)
            {
                for (int i = 0; i < client.Goods.Count; i++)
                    Console.WriteLine($"{i + 1} {client.Goods[i]}");

                int choice = Choice();

                if (client.Goods.Count > choice)
                    return client.Goods[choice];
            }
            else
                Console.WriteLine("У вас нет товаров");
            return new Package();

        }
        public static float TaxDeduction(Package Package)
        {
            if (Package.Goods.Sum(x => x.Price * x.Count) > 0)
            {
                float result = Package.Goods.Sum(x => x.Price * x.Count);
                return result *= 0.04f;
            }
            else return 0;
        }

    }
}
