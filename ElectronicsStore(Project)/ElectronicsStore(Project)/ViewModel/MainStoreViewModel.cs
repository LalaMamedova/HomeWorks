using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.ViewModel
{
    public class MainStoreViewModel:ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigateService;


        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);

        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public MainStoreViewModel(IMessenger messenger, INavigateService navigateService)
        {
            _messenger = messenger;
            _navigateService = navigateService;

            InitializationService.CategoryFromFile();
            InitializationService.ElectronicsListInitialization();
            InitializationService.AllElectronicsFromFile();

            CurrentViewModel = App.Container.GetInstance<HomeViewModel>();
            _messenger.Register<NavigationMessage>(this, ReceiveMessage);

        }

        public RelayCommand UserCabinetCommand
        {
            
            get => new(() => 
            {
                if (UserСabinetViewModel.UsLogined == true)
                {
                    _navigateService.NavigateTo<UserСabinetViewModel>(AuthViewModel.customer);
                }
                else
                    _navigateService.NavigateTo<AuthViewModel>();
            });
        }
        public RelayCommand BasketCommand
        {
            get => new(() => { _navigateService.NavigateTo<BasketViewModel>(BasketViewModel.Basket.Sum(x =>x.ThisElectronicPrice)); });
        }
    }
}
