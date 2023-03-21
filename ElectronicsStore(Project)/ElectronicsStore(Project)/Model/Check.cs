using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Check
    {
        public  ObservableCollection<Basket> Basket { get; set; } = new();
        public string Barcode { get; set; }
        public  float Price { get; set; }

    }
}
