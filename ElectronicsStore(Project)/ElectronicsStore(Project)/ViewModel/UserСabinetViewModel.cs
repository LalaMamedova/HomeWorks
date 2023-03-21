using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using ElectronicsStore_Project_.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.ViewModel
{
    internal class UserСabinetViewModel:ViewModelBase
    {

        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigationService;
        public static bool UsLogined = false;

        public string CabineteGreating { get => $"Личный кабинет {User.Login}"; }
        public Customer User { get; set; } = new();

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public UserСabinetViewModel(INavigateService navigationService, IMessenger messenger)
        {
            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == typeof(Customer).Name)
                {
                    User = (Customer)message.Data;
                }
            });
        }



        public RelayCommand BackCommand
        {
            get => new(() => { _navigationService.NavigateTo<HomeViewModel>(); });
        }

        public RelayCommand ToChecksCommand
        {
            get => new(() => { _navigationService.NavigateTo<CheckViewModel>(); });
        }
        public RelayCommand ToBasketCommand
        {
            get => new(() => { _navigationService.NavigateTo<BasketViewModel>(); });
        }

        public RelayCommand UserInfoCommand
        {
            get => new(() => 
            { 
                UserInfoView infoView = new();
                infoView.ShowDialog();
            });
        }
    }
}
