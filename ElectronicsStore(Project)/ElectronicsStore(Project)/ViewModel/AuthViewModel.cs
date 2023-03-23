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
using System.Windows;
using System.Windows.Controls;

namespace ElectronicsStore_Project_.ViewModel
{
    public class AuthViewModel:ViewModelBase
    {
        private readonly INavigateService _navigationService;
        private readonly ICustomerService _customerService;
        private readonly IMessenger _messenger;
        public static Customer customer { get; set; } = new(); 
        public AuthViewModel(INavigateService navigationService, IMessenger messenger, ICustomerService customerService)
        {
            _navigationService = navigationService;
            _customerService = customerService;
            _messenger = messenger;

            if (customerService.AllCustomers() != null)
                CustomerService.customersList = customerService.AllCustomers()!;
           
        }

        public RelayCommand<object> LoginCommand
        {
            get => new(param =>
            {
                object[] passwordArr = (object[])param;

                var password = (PasswordBox)passwordArr[0];
                customer.Password = password.Password;

                if (_customerService.IsCustomerExist(customer))
                {
                     UserСabinetViewModel.UsLogined = true;
                     customer = _customerService.GetCustomer(customer.Login, customer.Password);
                    _messenger.Send(new DataMessager() { Data = customer });
                    _navigationService.NavigateTo<HomeViewModel>();
                }
                else
                {
                    var button = MessageBox.Show("Такого пользователя не существует\nХотите зарегестрироваться?", "Ошибка входа",MessageBoxButton.YesNo);

                    if(button == MessageBoxResult.Yes)
                        _navigationService.NavigateTo<RegistrationViewModel>();
                }
            });
        }

        public RelayCommand RegistrationCommand
        {
            get => new(() => { _navigationService.NavigateTo<RegistrationViewModel>(); });
        }
        public RelayCommand PassForgotCommand
        {
            get => new(() =>
            {
                var window = new PassForgotView();
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
               
            });
        }

        public RelayCommand BackCommand
        {
            get => new(() =>{_navigationService.NavigateTo<HomeViewModel>();});
        }

    }
}
