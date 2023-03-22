using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        private readonly IMessenger _messenger;
        public static ObservableCollection<Electronics> SortedByCategory { get; set; } = new();
        public SearchService SearchService { get; set; } = new();

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }
        public AllProductsViewModel(INavigateService navigateService, IAdminService admin, IMessenger messenger)
        {
            _navigateService = navigateService;
            _adminService = admin;
            _messenger = messenger;
        }


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public RelayCommand BackToCategory
        {
            get => new(() => {_navigateService.NavigateTo<HomeViewModel>();});
        }

       
        public RelayCommand SearchCommand
        {
            get => new(() =>
            {
                int index = HomeViewModel.CategoryIndex;

                SearchService.SearchByName(index);
                SearchService.SearchByPrice(index);
                SearchService = new();

            });
        }

        public RelayCommand AddCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<AddProductViewModel>(DataBase.AllCategory[HomeViewModel.CategoryIndex]);

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
                        _navigateService.NavigateTo<RedactProductViewModel>(item);
                        break;
                    }
                }

            });
        }

        public RelayCommand<object> DeleteCommand
        {
            get => new(param =>
            {
                int index = HomeViewModel.CategoryIndex;
                foreach (var item in DataBase.ElectronicsList[index])
                {
                    if (item.ID == (int)param)
                    {
                        DataBase.ElectronicsList[index].Remove(item);
                        break;
                    }
                }
                Serialize.FileService.Truncate(DataBase.AllCategory[index].CategoryName + ".json");
                _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[index], DataBase.AllCategory[index].CategoryName + ".json");

            });
        }
    }
}
