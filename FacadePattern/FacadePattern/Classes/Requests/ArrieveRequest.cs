using FacadePattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes.Requests
{
    public class ArrieveRequest: IRequest
    {
        public Package Package { get; set; }
       
        public ArrieveRequest(Package package)
        {
            Package = package;
        }

      
        public void ShowArriveTime(DateTime dateTime)
        {
            var arrievetime = Package.ArrivalDate - dateTime;
            if(dateTime == Package.ArrivalDate)
                Console.WriteLine("Ваш товар уже доехал");
            else
                Console.WriteLine("Ваш товар доедет до вас " + arrievetime);
            
        }

        public void CancelTheOrder(Client client)
        {
            var returnBill = AnotherOperation.TaxDeduction(Package);
            client.Bill += returnBill;
            client.Goods.Remove(Package);
            Console.WriteLine("Вы успешно отменили товар " + returnBill + " вернулся на карту");

        }
    }
}
