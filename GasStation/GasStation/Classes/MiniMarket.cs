using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GasStation.Classes
{
    public class MiniMarket
    {
        public List<Food> Foods;
        public MiniMarket(params Food[] foods)
        {
            Foods = new();
            Foods.AddRange(foods);
        }
        public MiniMarket()
        {
            Foods= new() 
            {
                new Food("Хотдог",2.5f),
                new Food("Гамбургер",3.2f),
                new Food("Картошка Фри", 4.6f),
                new Food("Фанта",1.2f)
            };
        }
    }
}
