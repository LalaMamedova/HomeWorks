using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AdminPanel.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        private readonly IAdminService _adminService;
        public DataBase DataBase { get; set; } = new();
        public int CategoryIndex { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public HomeViewModel(INavigateService navigateService, IAdminService admin)
        {
            _navigateService = navigateService;
            _adminService = admin;
        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public void Indexdefinition(string param)
        {
            for (int i = 0; i < DataBase.AllCategory.Count; i++)
            {
                if (DataBase.AllCategory[i]!.CategoryName == param)
                {
                    CategoryIndex = i;
                    break;
                }
            }
        }
        public RelayCommand<object> ToSelectedCategory
        {
            get => new(param =>
            {
                try
                {
                    if (param != null)
                    {

                        Indexdefinition(param as string);

                        if (AllProductsViewModel.SortedByCategory.Count > 0)
                            AllProductsViewModel.SortedByCategory.Clear();

                        AllProductsViewModel.SortedByCategory = DataBase.ElectronicsList[CategoryIndex];

                        _navigateService.NavigateTo<AllProductsViewModel>(param);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }


        public RelayCommand<object> DeleteCommand
        {
            get => new(param =>
            {
                Indexdefinition(param as string);

                DataBase.AllCategory!.Remove(DataBase.AllCategory.Where(x => x!.CategoryName == (string)param).Single());//Сингл ибо за одно нажатие я могу удалить лишь 1 категорию

                DataBase.ElectronicsList[CategoryIndex].Clear();
                
                File.Delete(param as string + ".json");//Удаляю файл вообще
                Serialize.FileService.Truncate("AllCategory.json");

                if (DataBase.AllCategory.Count > 0)
                {
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory!, "AllCategory.json");
                }
            });
        }

     
        public RelayCommand<object> RedactCommand
        {
            get => new(param =>
            {
                Indexdefinition(param as string);
                MessageBox.Show(CategoryIndex.ToString());

                Serialize.FileService.Truncate("AllCategory.json");
                _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory!, "AllCategory.json");

                if (DataBase.ElectronicsList[CategoryIndex].Count > 0) 
                {
                    File.Move(DataBase.ElectronicsList[CategoryIndex][0].Category+".json", param as string + ".json");

                    foreach (var item in DataBase.ElectronicsList[CategoryIndex])
                        item.Category = param as string;

                    AllProductsViewModel.SortedByCategory = DataBase.ElectronicsList[CategoryIndex];

                    Serialize.FileService.Truncate(param + ".json");
                    _adminService.FromListToFile<ObservableCollection<Electronics>>(AllProductsViewModel.SortedByCategory, param as string + ".json");
                }
               
            });
        }

        

    }
}
