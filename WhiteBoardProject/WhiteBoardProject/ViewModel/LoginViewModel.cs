using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private INavigate _navigate;
        public string Email { get; set; }
        public User? User { get; set; } = new();
        public bool RememberMe{get; set; }


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

        public RelayCommand<PasswordBox> Login
        {
            get => new((password) =>
            {
                if (!string.IsNullOrEmpty(password.Password))
                {
                    User.Password = password.Password;
                    UserService userservice = new(User);
                    userservice.SendToServer("Exist");

                    User = userservice.Load();

                    if (User != null)
                    {
                        if (RememberMe)
                            RememberMeService.RememberMe(User);

                        _navigate.NavigateTo<HomeViewModel>(User);
                    }
                    else
                    {
                        MessageBoxResult mboxRes = MessageBox.Show("Неправильный пароль или email.\nХотите зарегистрироваться?", "Ошибка", MessageBoxButton.YesNoCancel);
                        if (mboxRes == MessageBoxResult.Yes)
                            _navigate.NavigateTo<RegistrationViewModel>();
                    }
                }
               
            }); 
        }
    }
}
