using ElectronicsStore_Project_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Classes
{
    public class SellConfirm
    {
        public  Basket Basket { get; private set; } = new();
        public static bool IsConfirmed = false;

        public SellConfirm(Electronic electronic)
        {
            Basket.Electronic = electronic;
            Basket.ThisElectronicPrice = electronic.Price;
            IsConfirmed = true;
        }
        public SellConfirm(){}




    }
}
