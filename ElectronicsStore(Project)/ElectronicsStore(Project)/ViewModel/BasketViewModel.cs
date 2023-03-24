using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using ElectronicsStore_Project_.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.ViewModel
{
    public class BasketViewModel : ViewModelBase
    {
 
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        private readonly IMessenger _messenger;

        public static ObservableCollection<Basket> Basket { get; set; } = new();
        public Price TotalCost { get; set; } = new(0);


        public BasketViewModel(INavigateService navigateService, IMessenger messenger = null)
        {
            _navigateService = navigateService;
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                if(message.Data.GetType().Name == TotalCost.TotalPrice.GetType().Name )
                    TotalCost.TotalPrice = (float)message.Data;
            });
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public RelayCommand<int> MinusCommand
        {
            get => new(param =>
            {
                foreach (var item in Basket)
                {
                    if (item.Electronic.ID == param)
                    {
                        if (item.ThisElectronicCount > 1)
                        {
                            item.ThisElectronicCount--;
                            item.ThisElectronicPrice -= item.Electronic.Price;
                            TotalCost.TotalPrice -= item.Electronic.Price;
                        }
                    }
                }
            });
        }

  
        public RelayCommand<int> PlusCommand
        {
            get => new(param =>
            {
                foreach (var item in Basket)
                {
                    if (item.Electronic.ID == param)
                    {
                        if (SellService.CountCheck(item.Electronic, item.ThisElectronicCount))
                        {
                            item.ThisElectronicCount++;
                            item.ThisElectronicPrice += item.Electronic.Price;
                            TotalCost.TotalPrice += item.Electronic.Price;
                        }
                        else
                            MessageBox.Show($"Количество товара на складе {item.Electronic.Count}") ;
                    }
                }

            });
        }

        public RelayCommand<ObservableCollection<Basket>> ConfirmCommand
        {
            get => new(param =>
            {
                var res = param.Count;
                if (res > 0)
                {
                    if (UserСabinetViewModel.UsLogined == true)
                    {
                        _messenger.Send(new DataMessager() { Data = AuthViewModel.customer.Card! });
                        BankCardView bankCardView = new BankCardView();
                        bankCardView.ShowDialog();

                        if (SellConfirm.IsConfirmed == true)
                        {
                            _messenger.Send(new DataMessager() { Data = param });
                            SellService.Rewrite();
                            Basket.Clear();
                            TotalCost.TotalPrice = 0;
                            SellConfirm.IsConfirmed = false;
                        }
                    }

                    else if (UserСabinetViewModel.UsLogined == false)
                    {
                        MessageBox.Show("Войдите прежде чем подтвердить покупку");
                    }
                }
                else
                    MessageBox.Show("У вас пустая корзинка", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            });
        }

        public RelayCommand<int> DeleteCommand
        {
            get => new(param =>
            {
                for (int i = 0; i < Basket.Count; i++)
                {
                    if (Basket[i].Electronic.ID == param)
                    {
                        TotalCost.TotalPrice -= Basket[i].ThisElectronicPrice;
                        Basket.RemoveAt(i);
                    }
                }
            });
        }

    }
}
