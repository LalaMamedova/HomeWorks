using AdminPanel.Model;
using AdminPanel.View;
using AdminPanel.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Service.Classes
{
    public class SearchService : INotifyPropertyChanged
    {
    
        private  string? electronicName;
        private  ObservableCollection<Electronics> sorted;
        public  float MinPrice { get; set; }
        public  float MaxPrice{ get; set; }
        public  string? ElectronicName { get; set; }

        public ObservableCollection<Electronics> Sorted { get => AllProductsViewModel.SortedByCategory; set => sorted = value; } 

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
