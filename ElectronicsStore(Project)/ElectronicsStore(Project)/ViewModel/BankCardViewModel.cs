using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.ViewModel
{
    public class BankCardViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        public Customer? Customer { get; set; } = new();
        public BankCard Card { get; set; } = new();
        public DataBase DataBase { get; set; } = new();

        public BankCardViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == typeof(BankCard).Name)
                {
                    Card = (BankCard)message.Data;
                }
            });
        }

        public RelayCommand SellConfirmedCommand
        {
            get => new(() =>
            {
                SellConfirm.IsConfirmed = true;
                _messenger.Send(new DataMessager() { Data = Card.CardNumber! });
            });
        }
        
    }
}
