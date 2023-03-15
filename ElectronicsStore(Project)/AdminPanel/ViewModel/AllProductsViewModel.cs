using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly IAdminService _adminService;
        private readonly INavigateService _navigateService;
        public static ObservableCollection<Electronics> SortedByCategory { get; set; } = new();

        public int MinPrice { get; set; } 
        public int MaxPrice { get; set; } 
        public string Processor { get; set; } 

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public AllProductsViewModel(INavigateService navigateService, IAdminService admin)
        {
            _navigateService = navigateService;
            _adminService = admin;
        }


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public RelayCommand BackToCategory
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<HomeViewModel>();
            });
        }


        public RelayCommand SortPriceCommand
        {
            get => new(() =>
            {
                MessageBox.Show(MinPrice.ToString());
                if (MinPrice > 0)
                {
                    SortedByCategory.OrderBy(x => x.Price >= MinPrice);
                }
            });
        }

        public RelayCommand<object> RedactCommand
        {
            get => new(param =>
            {
                foreach (var item in SortedByCategory)
                {
                    if (item.ID == (int)param)
                    {
                        _navigateService.NavigateTo<AddProductViewModel>(item);
                        break;
                    }
                }

            });
        }

        public RelayCommand<object> DeleteCommand
        {
            get => new(param =>
            {
               
                //foreach (var item in DataBase.AllElectronics)
                //{
                //    if (item.ID == (int)param)
                //    {
                //        DataBase.AllElectronics.Remove(item);
                //        break;
                //    }
                //}

                //FileStream fileStream = new("AllElectronics.json", FileMode.Truncate);
                //fileStream.Close();

                //_adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.AllElectronics, "AllElectronics.json");

            });
        }
    }
}
