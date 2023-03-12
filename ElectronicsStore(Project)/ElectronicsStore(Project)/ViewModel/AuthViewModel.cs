using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.ViewModel
{
    public class AuthViewModel:ViewModelBase
    {
        private readonly INavigateService _navigationService;

        public AuthViewModel(INavigateService navigationService)
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

        public RelayCommand RegistrationCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<RegistrationViewModel>();
            });
        }

    }
}
