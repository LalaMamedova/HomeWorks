using FacadePattern.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes.Requests
{
    public class BuyGoods : IRequest
    {
        public Package Package { get; set; }
        public Package BuyGood(Client client)
        {
            int stop = 1;
            Package = new();

            while (stop != 0)
            {
                for (int i = 0; i < DataBase.goods.Count; i++)
                    Console.WriteLine(i + 1 + " " + DataBase.goods[i]);

                int choice = AnotherOperation.Choice();

                if (choice < DataBase.goods.Count)
                {
                    Package.Goods.Add(DataBase.goods[choice]);

                    Console.WriteLine("Введите количество товара");
                    Package.Goods.Last().Count = int.Parse(Console.ReadLine());

                    Package.Goods.Last().Price = DataBase.goods[choice].Price * Package.Goods.Last().Count;

                    Package.Adress = client.Adress;
                    client.Goods.Add(Package);
                    Console.Clear();

                    Console.WriteLine("Продолжить покупку? \n1.Да\n0.Нет");
                    stop = int.Parse(Console.ReadLine());

                    Console.Clear();
                }
            }
            Package.ArrivalDate = Package.OrderDate.AddMonths(2);
            client.Bill -= AnotherOperation.TaxDeduction(Package);
            client.Goods.Last().TotalSum  = Package.Goods.Sum(x=>x.Price * x.Count);
            return Package;
        }

        public float ReturnCach(Client client)
        {
            if (client.HasACard)
            {
                float total = client.Goods.Sum(x => x.TotalSum);
                Console.WriteLine("Вы вернули себе " + total);
                return total * 0.02f;
            }
            else  return 0;
        }
       
        public void AddressRequest(Client client,Package Package)
        {
            int choice = 0;
            Console.WriteLine("Введите адресс доставки" +
                "\n1.Доставить на мой адресс" +
                "\n2.Ввести другой адресс");

            choice = Int32.Parse(Console.ReadLine());

            if (choice == 1) { Package.Adress = client.Adress; }
            else if (choice == 2)
            {
                Console.WriteLine("Введите новый адресс");
                Package.Adress = Console.ReadLine();
            }

            Package.ArrivalDate = Package.OrderDate.AddMonths(1);

        }

        


    }
}
