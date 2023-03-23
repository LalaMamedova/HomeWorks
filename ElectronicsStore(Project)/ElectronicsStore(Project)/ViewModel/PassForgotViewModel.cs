using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ElectronicsStore_Project_.Messanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore_Project_.Service.Classes;
using System.ComponentModel;

namespace ElectronicsStore_Project_.ViewModel
{
    public class PassForgotViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private readonly ICustomerService _customerService;
        private string usersPassword;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Customer User { get; set; } = new();
        public string UsersPassword
        {
            get => usersPassword; set
            {
                usersPassword = value;
                NotifyPropertyChanged(nameof(UsersPassword));
            }
        }

        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public PassForgotViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public RelayCommand ShowPasswordCommand
        {
            get => new(() =>
            {
                if (!string.IsNullOrEmpty(User.Email))
                {
                    string? password = _customerService.GetPassword(User.Email);
                    UsersPassword = password;
                }
                else
                    UsersPassword = "";
            });
        }


    }
}
