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

namespace ElectronicsStore_Project_.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {
        private readonly INavigateService _navigationService;

        public Customer User { get; set; } = new();

        public RegistrationViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }
        public RelayCommand LoginCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AuthViewModel>();
            });
        }

        //public RelayCommand<object> RegisterCommand
        //{
        //    get => new(
        //        param =>
        //        {
        //            if (param != null)
        //            {
        //                object[] passwordArr = (object[])param;

        //                var password = (PasswordBox)passwordArr[0];
        //                var confirm = (PasswordBox)passwordArr[1];

        //                var checker = new PasswordService(password, confirm);

        //                if (checker.IsMatch() && !_userService.CheckExists(User.Username, password.Password))
        //                {
        //                    User.Password = password.Password;
        //                    User.ConfirmPassword = confirm.Password;

        //                    _userService.Add(User);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No");
        //                }
        //            }
        //        });
        //}
    }
}
