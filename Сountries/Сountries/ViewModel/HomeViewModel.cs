using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сountries.Dates.Contexts;
using Сountries.Services.Classes;
using Сountries.Services.Interfaces;

namespace Сountries.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private INavigate _navigate;
        private IMessenger _messenger;
        private ViewModelBase? _currentViewModel;

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }

        public HomeViewModel(INavigate navigate, IMessenger messenger)
        {
            _navigate = navigate;
            _messenger = messenger;

            CurrentViewModel = App.Container.GetInstance<MainViewModel>();
            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }
    }
}
