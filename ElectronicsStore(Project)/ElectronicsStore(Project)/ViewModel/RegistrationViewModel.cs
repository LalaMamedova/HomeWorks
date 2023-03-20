using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ElectronicsStore_Project_.Service.Classes;
using GalaSoft.MvvmLight.Messaging;

namespace ElectronicsStore_Project_.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {
        private static int iD { get; set; }
        private readonly INavigateService _navigationService;
        private readonly ICustomerService _customerService;
        public Customer User { get; set; } = new();

        //public static int _ID           /////Почему то не работает(не десериализует)
        //{
        //    get => iD;

        //    private set
        //    {
        //        var IdFile = IDService.DesirializeID("CustomersID.json");
        //        iD = IdFile;
        //    }
        //}

        public RegistrationViewModel(INavigateService navigationService, ICustomerService customerService)
        {
            _navigationService = navigationService;
            _customerService = customerService;

            var IdFile = IDService.DesirializeID("CustomersID.json");
            iD = IdFile;
            
           
        }
        public RelayCommand LoginCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AuthViewModel>();
            });
        }

        public RelayCommand<object> RegisterCommand
        {
            get => new(
                param =>
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
                            User.ID = iD;

                            _customerService.Add(User);
                            iD++;   
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают");
                        }
                    }
                });
        }
    }
}
