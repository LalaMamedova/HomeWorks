﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal;
using ProjectLib.Model.Class;
using ProjectLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;
using WhiteBoardProject.View;
using WhiteboardServer.Service.Classes;

namespace WhiteBoardProject.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private INavigate _navigate;
        private IMessenger _messanger;
        private ViewModelBase? _currentViewModel;
        private User? RecivedUser;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);
        public MainViewModel(INavigate navigate, IMessenger messanger)
        {
            _navigate = navigate;
            _messanger = messanger;

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            IUser? userDTO = RememberMeService.LoadRememberedUser();
            UserService userService = new();

            if (userDTO != null)
            {
                userService.SendToServer("Exist", userDTO);
                RecivedUser = await userService.ReciveAsync<User>();

                if (RecivedUser != null)
                {
                    CurrentViewModel = App.Container.GetInstance<HomeViewModel>();
                    _messanger.Send(new DataMessager() { Data = RecivedUser });
                    _messanger.Register<NavigationMessage>(this, ReceiveMessage);
                }
            }
            else
            {
                CurrentViewModel = App.Container.GetInstance<LoginViewModel>();
                _messanger.Register<NavigationMessage>(this, ReceiveMessage);
            }
        }



    }
}
