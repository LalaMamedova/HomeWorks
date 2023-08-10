using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        private INavigate _navigate;
        public User User { get; set; } =  new User() { Email="lallol606@gmail.com", Password ="lala", UserArts = new List<UserArt>()};
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
                        //_navigate.NavigateTo<DrawViewModel>(User);
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
