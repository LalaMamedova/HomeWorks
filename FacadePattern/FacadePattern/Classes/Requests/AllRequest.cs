using FacadePattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes.Requests
{
    public class AllRequest:IRequest
    {
        private IRequest request;
        public Package Package { get; set; }
        public Client Client { get; set; }  

        public Client ClientInfo(string addres, float bill, bool hascard)
        {
            Client = new();

            Client.Adress = addres;
            Client.Bill = bill;
            Client.HasACard = hascard;

            Console.Clear();
            return Client;
        }
      

        public void ChoiceTheRequest()
        {
            int choice = 1;

            while (choice > 0)
            {

                Console.WriteLine("1.Заказать товар" +
                "\n2.Изменить адресс посылки" +
                "\n3.Вернуть себе кэш" +
                "\n4.Посмотреть дату доставки товара" +
                "\n5.Отменить заказ" +
                "\n6.Посмотреть историю заказов" +
                "\n0.Выйти");

                choice = Int32.Parse(Console.ReadLine());
              

                if (choice < 3)
                {
                    request = new BuyGoods();
                    if (choice == 1)
                        ((BuyGoods)request).BuyGood(Client);
                    else if (choice == 2)
                    {
                        Package = AnotherOperation.ClientGoodsChoice(Client);
                        ((BuyGoods)request).AddressRequest(Client, Package);
                    }
                    else if (choice == 3)
                        ((BuyGoods)request).ReturnCach(Client);

                    Client.Myrequest.Add(request);

                }
                else if (choice > 3 && choice <= 5)
                {
                    Package = AnotherOperation.ClientGoodsChoice(Client);

                    request = new ArrieveRequest(Package);

                    if (choice == 4)
                    {
                        ((ArrieveRequest)request).ShowArriveTime(DateTime.Now);
                    }
                    else if (choice == 5)
                    {
                        ((ArrieveRequest)request).CancelTheOrder(Client);
                    }
                    Client.Myrequest.Add(request);

                }
                else if (choice == 6)
                {
                    foreach (var item in Client.Myrequest)
                    {
                        Console.WriteLine(item.GetType().Name);
                    }
                }

                Console.WriteLine("Нажмите на Enter");
                Console.ReadKey();
                Console.Clear();

            }
          
        }
    }
}
