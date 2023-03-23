using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class DataBase
    {
        public static ObservableCollection<Category?>? AllCategory { get; set; } = new();
        public static ObservableCollection<ObservableCollection<Electronic>>? ElectronicsList { get; set; } = new();
        public static ObservableCollection<Electronic>? AllElectronics { get; set; } = new();
        public static ObservableCollection<string>? CardType { get; set; } = new() { "Visa", "MasterCard", "Maestro" };


    }
}
