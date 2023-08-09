using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ProjectLib.Model.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
