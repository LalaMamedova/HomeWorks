using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM_First_App.Message;
using MVVM_First_App.Service;
using MVVM_First_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_First_App.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigateService;

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

        public MainWindowViewModel(IMessenger messenger, INavigateService navigateService)
        {
            CurrentViewModel = App.Container.GetInstance<EmptyControlViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
            _navigateService = navigateService;
        }

        public RelayCommand FirstButtonCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<FirstButtomViewModel>();
            });
        }

        public RelayCommand SecondButtonCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<SecondButtonViewModel>();
            });
        }

        public RelayCommand ThirdButtonCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<ThirdButtonViewModel>();
            });
        }

    }
}
