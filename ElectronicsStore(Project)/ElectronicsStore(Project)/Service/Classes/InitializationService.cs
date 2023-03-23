using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.ViewModel;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Classes
{
    public class InitializationService
    {
        public static void CategoryFromFile()
        {
            var json = FileService.Read(FilePath.path + "AllCategory.json");
            if (json != null)
            {
                DataBase.AllCategory = SerializeLibary.Deserialize<ObservableCollection<Category?>>(json);
            }
           
        }

        public static void ElectronicsListInitialization()
        {
            for (int i = 0; i < DataBase.AllCategory?.Count; i++)
            {
                DataBase.ElectronicsList.Add(new ObservableCollection<Electronic>());
            }
        }

        public ObservableCollection<Electronic> SelectedCategoryFromFile()
        {
            var Products = FileService.Read(FilePath.path + DataBase.AllCategory[HomeViewModel.CategoryIndex].CategoryName + ".json");
            ObservableCollection<Electronic> newElectronic = new();
            if (!string.IsNullOrEmpty(Products))
            {
                newElectronic = SerializeLibary.Deserialize<ObservableCollection<Electronic>>(Products);
            }
            return newElectronic;
        }

        public static void AllElectronicsFromFile()
        {
            int i = 0;
            foreach (var category in DataBase.AllCategory)
            {
                var Products = FileService.Read(FilePath.path + category.CategoryName + ".json");
                var TempElecronics = SerializeLibary.Deserialize<ObservableCollection<Electronic>>(Products);

                if (TempElecronics != null)
                {
                    foreach (var electronics in TempElecronics)
                        DataBase.AllElectronics.Add(electronics);
                    

                    DataBase.ElectronicsList[i] = TempElecronics;
                    
                }
                i++;
            }
        }
    }
}
