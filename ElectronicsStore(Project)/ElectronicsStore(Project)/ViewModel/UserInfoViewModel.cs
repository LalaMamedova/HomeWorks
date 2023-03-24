using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;

namespace ElectronicsStore_Project_.ViewModel
{
    public class UserInfoViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IMessenger _messenger;
        private readonly ICustomerService _customerService;
        private bool isTextEnable = false;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


       
        public Customer User { get; set; } = new();
        public DataBase DataBase { get; set; } = new();
        public bool IsTextEnable { get => isTextEnable; set { isTextEnable = value; NotifyPropertyChanged(nameof(IsTextEnable)); } }
        public UserInfoViewModel(IMessenger messenger, ICustomerService customerService)
        {
            _messenger = messenger;
            _customerService = customerService;

            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == typeof(Customer).Name)
                    User = (Customer)message.Data;
            });
        }


        public RelayCommand<object> SaveNewPasswordCommand
        {
            get => new(param =>
            {
                if (param != null)
                {
                    object[] passwordArr = (object[])param;

                    var password = (PasswordBox)passwordArr[0];
                    var confirm = (PasswordBox)passwordArr[1];

                    var checker = new PasswordService(password, confirm);

                    if (checker.IsMatch())
                    {
                        User.Password = password.Password;
                        User.ConfirmPassword = confirm.Password;
                        _customerService.Redact(User);
                    }

                }
            });
        }

        public RelayCommand SaveChanges
        {
            get => new(() =>
            {
                _customerService.Redact(User);
                IsTextEnable = false;
            });
        }

        public RelayCommand RedactBankCardCommand
        {
            get => new(() =>
            {
                if (IsTextEnable == true)
                    IsTextEnable = false;
                else
                    IsTextEnable = true;
            });
        }
    }
}
