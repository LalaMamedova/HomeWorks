using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicsStore_Project_.Service.Interfaces;
using ElectronicsStore_Project_.Messanger;

namespace ElectronicsStore_Project_.Service.Classes
{
    internal class NavigationService : INavigateService
    {
        private readonly IMessenger _messenger;
       
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
    }
}
