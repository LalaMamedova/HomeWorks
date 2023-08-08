using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private INavigate _navigate;
        public LoginViewModel(INavigate navigate)
        {
            _navigate = navigate;
        }
        public RelayCommand ToSignUp
        {
            get => new(() =>
            {
                _navigate.NavigateTo<RegistrationViewModel>();
            });
        }
    }
}
