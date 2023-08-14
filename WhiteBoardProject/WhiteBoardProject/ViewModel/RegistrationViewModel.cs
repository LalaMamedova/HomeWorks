﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class RegistrationViewModel:ViewModelBase
    {
        private INavigate _navigate;
        public User? RegistratedUser { get; set; } = new();
        public UserDTO User { get; set; } = new();
        public RegistrationViewModel(INavigate navigate) 
        {
            _navigate = navigate;
        }
        public RelayCommand ToLogin
        {
            get => new(() => 
            {
                _navigate.NavigateTo<LoginViewModel>();
            });
        }

        public RelayCommand<object> RegisterCommand
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
                        UserService userService = new();
                        userService.SendToServer("Add",User);
                        RegistratedUser = (User)userService.Recive();
                        _navigate.NavigateTo<DrawViewModel>(User);
                    }

                }
            });
        }
    }
}
