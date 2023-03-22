using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.View;
using ElectronicsStore_Project_.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Classes
{
    public class SearchService : INotifyPropertyChanged
    {
        private  float minPrice = 0;
        private  float maxPrice;
        private  string? electronicName;
        private  ObservableCollection<Electronic> sorted;

        public  float MinPrice
        {
            get => minPrice;
            set
            {
                minPrice = value;
                //NotifyPropertyChanged(nameof(MinPrice));
            }
        }

        public  float MaxPrice
        {
            get => maxPrice;
            set
            {
                maxPrice = value;
                //NotifyPropertyChanged(nameof(MaxPrice));
            }
        }


        public  string? ElectronicName
        {
            get => electronicName;
            set
            {
                electronicName = value;
                //NotifyPropertyChanged(nameof(ElectronicName));
            }
        }

        public ObservableCollection<Electronic> Sorted { get => SelectedCategoryProductsViewModel.SortedByCategory; set => sorted = value; } 

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public  void SearchByName(int index)
        {
            if (!string.IsNullOrEmpty(ElectronicName))
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Name != ElectronicName)
                    {
                        Sorted.RemoveAt(i);
                        i--;
                    }
                }
            }
        }


        public  void SearchByPrice(int index)
        {
            if (MinPrice > 0 || MaxPrice > 0)
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Price > MaxPrice && DataBase.ElectronicsList[index][i].Price > MinPrice)
                    {
                        Sorted.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

    }
}
