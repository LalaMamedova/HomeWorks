using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStation.Classes
{
    public class Food
    {
        public string FoodName { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }

        public Food(string foods, float price, int count)
        {
            FoodName = foods;
            Price = price;
            Count = count;
        }
        public Food(string foods, float price)
        {
            FoodName = foods;
            Price = price;
        }

        public Food() { }

        public override string ToString() => $"{FoodName}  {Price}  {Count}";
        
    }
}
