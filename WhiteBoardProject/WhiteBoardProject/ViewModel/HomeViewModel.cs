using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Humanizer;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private readonly INavigate _navigate;
        private readonly IMessenger _messenger;
        public User ActiveUser { get; set; }
        public UserArt UserArt { get; set; }
        public double Width { get; set; } = SystemParameters.PrimaryScreenWidth;
        public double Height { get; set; } = SystemParameters.PrimaryScreenHeight;

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
                UserArt = new() { Width = Width, Height = Height};
                _navigate.NavigateTo<DrawViewModel>(UserArt);
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
                UserArt art = ActiveUser.UserArts.Where(x => x.Id == artId).First();
                IWhiteboardtService whiteboardtService; 
                try
                {
                    ArtService artService = new ArtService(art);
                    artService.SendToServer("Delete", art);
                    artService.DeleteFromFtp();
                    if (File.Exists(art.PicturePath))
                    {
                        File.Delete(art.PicturePath);
                    }
                    ActiveUser.UserArts.Remove(art);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              

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

        public RelayCommand<ItemsControl> Refresh
        {
            get => new((itemcontrol) =>
            {
                ObservableCollection<UserArt> userArts = new();

                //foreach (var item in ActiveUser.UserArts)
                //    userArts.Add(item);
                
                itemcontrol.ItemsSource = ActiveUser.UserArts; 
            });
        }


    }
}
