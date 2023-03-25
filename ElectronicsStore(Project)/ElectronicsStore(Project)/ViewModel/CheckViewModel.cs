using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace ElectronicsStore_Project_.ViewModel
{
    public class CheckViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        private readonly IMessenger _messenger;
        public Check NewCheck;
        
        public static ObservableCollection<Check> CheckList { get; set; } = new();

        public CheckViewModel(INavigateService navigateService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {

                if (message.Data.GetType().Name == typeof(ObservableCollection<Basket>).Name)
                {
                    foreach (Basket item in (ObservableCollection<Basket>)message.Data)
                    {
                        NewCheck!.Basket.Add(item);
                    }

                    NewCheck!.Price = NewCheck.Basket.Sum(x => x.ThisElectronicPrice);
                    CheckList.Add(NewCheck);
                   
                }

                else if (message.Data.GetType().Name == "".GetType().Name)
                {
                    NewCheck = new();
                    NewCheck.UserCardNumber = message.Data as string;
                }

                else if (SellConfirm.IsConfirmed == true)
                {
                    SellConfirm? sellConfirm = message.Data as SellConfirm;
                    OnePrudct(NewCheck, sellConfirm.Basket);
                }
        
            });
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);


        private void OnePrudct(Check NewCheck, Basket sellConfirm)
        {
            NewCheck.Basket.Add(sellConfirm!);

            NewCheck.Price = sellConfirm.Electronic.Price;
            CheckList.Add(NewCheck);

            SellConfirm.IsConfirmed = false;
           
        }

        public RelayCommand BackCommand
        {
            get => new(() => { _navigateService.NavigateTo<HomeViewModel>(); });
        }
    }
}
