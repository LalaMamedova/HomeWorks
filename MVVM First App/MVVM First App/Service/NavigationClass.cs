using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVM_First_App.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_First_App.Service
{
    internal class NavigationClass : INavigateService
    {
        private readonly IMessenger _messenger;
       
        public NavigationClass(IMessenger messenger)
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
