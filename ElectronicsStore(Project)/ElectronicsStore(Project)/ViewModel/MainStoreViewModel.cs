using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.ViewModel
{
    public class MainStoreViewModel:ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigateService;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public MainStoreViewModel(IMessenger messenger, INavigateService navigateService)
        {
            _messenger = messenger;
            _navigateService = navigateService;


            var json = FileService.Read(FilePath.path + "AllCategory.json");
            DataBase.AllCategory = SerializeLibary.Deserialize<ObservableCollection<Category?>>(json);

            for (int i = 0; i < DataBase.AllCategory.Count; i++)
                DataBase.ElectronicsList.Add(new ObservableCollection<Electronic>());

            CurrentViewModel = App.Container.GetInstance<HomeViewModel>();
            _messenger.Register<NavigationMessage>(this, ReceiveMessage);

        }
    }
}
