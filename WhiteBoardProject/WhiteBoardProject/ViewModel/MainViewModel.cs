using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.Service.Interface;

namespace WhiteBoardProject.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private INavigate _navigate;
        private IMessenger _messanger;
        private ViewModelBase? _currentViewModel;
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

            CurrentViewModel = App.Container.GetInstance<RegistrationViewModel>();
            _messanger.Register<NavigationMessage>(this, ReceiveMessage);
        }

     
    }
}
