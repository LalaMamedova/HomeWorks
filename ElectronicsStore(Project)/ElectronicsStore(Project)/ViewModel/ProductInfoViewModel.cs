using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ElectronicsStore_Project_.ViewModel
{
    public class ProductInfoViewModel: ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigationService;
        private InitializationService _initializationService = new();
       
        public string FullName { get => Electronic.Category + " " + Electronic.Name + " " + Electronic.Memory; }
        public string LeftCount { get => "Осталось " + Electronic.Count + " штук!"; }
        public Electronic Electronic { get; set; } = new();

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public ProductInfoViewModel(INavigateService navigationService, IMessenger messenger)
        {
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<DataMessager>(this, message =>
            {
                if(message.Data.GetType().Name == typeof(Electronic).Name)
                    Electronic = (Electronic)message.Data;
            });

        }

        public RelayCommand BackToCategory
        {
            get => new(() => 
            {
                HomeViewModel.CategoryIndex = Electronic.CategoryIndex;
                SelectedCategoryProductsViewModel.SortedByCategory = DataBase.ElectronicsList[HomeViewModel.CategoryIndex];
                _navigationService.NavigateTo<SelectedCategoryProductsViewModel>();
            });
        }

        public RelayCommand<object> ToBasketCommand
        {
            get => new(param => 
            {
                if (SellService.IsSoldOut(Electronic))
                {
                    Basket basket = new Basket();
                    basket.Electronic = Electronic;
                    BasketService.AddToBasket(basket);
                }
            });
        }


        public RelayCommand<object> BuyCommand
        {
            get => new(param =>
            {
                bool countRes = SellService.IsSoldOut(Electronic);
                if (countRes && UserСabinetViewModel.UsLogined == true)
                {
                    SellConfirm sellConfirm = new(Electronic);
                    _messenger.Send(new DataMessager() { Data = sellConfirm });
                }

                else if (UserСabinetViewModel.UsLogined == false && countRes)
                {
                    _navigationService.NavigateTo<AuthViewModel>();
                }
            });
        }



    }
}
