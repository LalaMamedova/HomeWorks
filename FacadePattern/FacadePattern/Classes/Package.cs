using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class Package
    {
        public List<Good> Goods { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ArrivalDate { get; set; }
        public string Adress { get; set; }
        public float TotalSum { get; set; }
        

        public Package() { }
        public Package(DateTime orderDate, DateTime arrivalDate, params Good[] goods)
        {
            Goods.AddRange( goods);
            OrderDate = orderDate;
            ArrivalDate = arrivalDate;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("товары заказа: \n");

            foreach (var item in Goods)
            {
                stringBuilder.Append(item.ToString() +  "\n");
            }
            stringBuilder.Append($"Время заказа: {OrderDate.ToShortDateString()}\tВремя Прихода: {ArrivalDate.ToShortDateString()}\tАдресс: {Adress}"); 
            return stringBuilder.ToString();
        }
    }
}
