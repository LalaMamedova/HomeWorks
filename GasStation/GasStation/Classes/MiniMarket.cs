using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation.Classes
{
    public enum Foods { HotDog = 0, Burger,FrienchFries,Fanta};
    public class MiniMarket
    {
        public Foods Foods { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }

        public MiniMarket(Foods foods, float price, int count)
        {
            Foods = foods;
            Price = price;
            Count = count;
        }

        public MiniMarket() 
        {
            Foods foods = new();
            foods = Foods.HotDog;
            Price = 4.4f;
            Count = 1;
        }
    }
}
