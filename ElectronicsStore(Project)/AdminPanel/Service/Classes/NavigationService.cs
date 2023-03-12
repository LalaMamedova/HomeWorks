using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Service.Interfaces;
using AdminPanel.Messanger;

namespace AdminPanel.Service.Classes
{
    internal class NavigationService : INavigateService
    {
        private readonly IMessenger _messenger;
        public object Data { get; set; }
        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }


        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });
        }

        public void NavigateTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });

            Data = data;
        }
    }
}
