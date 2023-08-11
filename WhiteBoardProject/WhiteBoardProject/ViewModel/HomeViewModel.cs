using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private readonly INavigate _navigate;
        private readonly IMessenger _messenger;
        public User ActiveUser { get; set; } = new();
        public double Width { get; set; } = SystemParameters.PrimaryScreenWidth;
        public double Height { get; set; } = SystemParameters.PrimaryScreenHeight;
        public UserArt userArt { get; set; }

        public HomeViewModel(INavigate navigate, IMessenger messenger)
        {
            _navigate = navigate;
            _messenger = messenger;
            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == nameof(User))
                {
                    ActiveUser = message.Data as User;
                }
            });
        }

        public RelayCommand AddNewArt
        {
            get => new(() =>
            {
                userArt = new() { Width = Width, Height = Height};
                _navigate.NavigateTo<DrawViewModel>(userArt);
                _messenger.Send(new DataMessager() { Data = ActiveUser });

            });
        }

        public RelayCommand<int> ToRedact
        {
            get => new((artId) =>
            {
                var art = ActiveUser.UserArts.Where(x => x.Id == artId).First();
                DrawViewModel.isRedact = true;
                _navigate.NavigateTo<DrawViewModel>(art);
                _messenger.Send(new DataMessager() { Data = ActiveUser });

            });
        }

        public RelayCommand<int> DeleteArt
        {
            get => new((artId) =>
            {
                var art = ActiveUser.UserArts.Where(x => x.Id == artId).First();
                ArtService pictureService = new ArtService(art);
                ActiveUser.UserArts.Remove(art);
                pictureService.SendToServer("Delete");

                RememberMeService.RememberMe(ActiveUser);
                pictureService.DeleteFromFtp();

            });
        }

        public RelayCommand Logout
        {
            get => new(() =>
            {
                ActiveUser = new();
                RememberMeService.DeleteRememberedUser();
                _navigate.NavigateTo<LoginViewModel>(ActiveUser);
            });
        }


    }
}
