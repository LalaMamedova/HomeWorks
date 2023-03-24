using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.ViewModel;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.Service.Classes
{
    public class SellService
    {
        public static void SubtractQuantity()
        {
            foreach (var products in BasketViewModel.Basket)
            {
                products.Electronic.Count -= products.ThisElectronicCount;
            }
        }

        public static bool CountCheck(Electronic electronic, int SelCount)
        {
            if (electronic.Count > SelCount) return true;
            return false;
        }
        public static void Rewrite()
        {
            SubtractQuantity();

            for (int i = 0; i < DataBase.AllCategory?.Count; i++)
            {
                if (DataBase.ElectronicsList[i].Count > 0)
                {
                    string? json = SerializeLibary.Serialize<ObservableCollection<Electronic>>(DataBase.ElectronicsList[i]);
                    FileService.Truncate(FilePath.path + DataBase.AllCategory[i]!.CategoryName + ".json");
                    FileService.Write(json, FilePath.path + DataBase.AllCategory[i]!.CategoryName + ".json");
                }
            }
           
        }
      
        public static bool IsSoldOut(Electronic Electronic)
        {
            if (Electronic.Count > 0)
            {
                return true;
            }
            else if (Electronic.Count == 0)
            {
                MessageBox.Show("Этого товара нет в наличии" +
                  "\nПожалуйста, дождитесь пополнения запаса", "Ошибка при покупке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

       
    }
}
