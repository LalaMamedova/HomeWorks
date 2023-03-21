using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.View;
using ElectronicsStore_Project_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Classes
{
    public class SearchService
    {
        public  int MinPrice { get; set; }
        public  int MaxPrice { get; set; }
        public string? ElectronicName { get; set; }

        public void SearchByName(int index)
        {
            if (!string.IsNullOrEmpty(ElectronicName))
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Name != ElectronicName)
                    {
                        SelectedCategoryProductsViewModel.SortedByCategory.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public void SearchByPrice(int index)
        {
            if (MinPrice > 0 || MaxPrice > 0)
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Price > MaxPrice && DataBase.ElectronicsList[index][i].Price > MinPrice)
                    {
                        SelectedCategoryProductsViewModel.SortedByCategory.RemoveAt(i);
                        i--;
                    }
                }
            }
        }


    }
}
