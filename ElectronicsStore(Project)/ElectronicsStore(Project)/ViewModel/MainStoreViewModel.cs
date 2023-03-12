using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.ViewModel
{
    public class MainStoreViewModel:ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly IMessenger _messenger;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref _currentViewModel, value);
            }
        }

        public void ReceiveMessage(NavigationMessage message)
        {
            CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);
        }

        public MainStoreViewModel(IMessenger messenger)
        {
            CurrentViewModel = App.Container.GetInstance<AuthViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
           
        }
    }
}
