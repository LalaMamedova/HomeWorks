using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    internal class MainAdminViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;
        private IAdminService _adminService;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigateService;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }


        public void ReceiveMessage(NavigationMessage message) =>CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public MainAdminViewModel(IMessenger messenger, INavigateService navigateService, IAdminService adminService)
        {
            _messenger = messenger;
            _navigateService = navigateService;
            _adminService = adminService;

            var allCategory = _adminService.FromFileToList<ObservableCollection<Category>>("AllCategory.json");
            if (allCategory != null) DataBase.AllCategory = allCategory!;

            for (int i = 0; i < DataBase.AllCategory.Count; i++)
            {
                DataBase.ElectronicsList.Add(new ObservableCollection<Electronics>());
                var res = _adminService.FromFileToList<ObservableCollection<Electronics>>(DataBase.AllCategory[i]?.CategoryName + ".json");

                if (res != null)
                    DataBase.ElectronicsList[i] = res;
            }
           
            CurrentViewModel = App.Container.GetInstance<HomeViewModel>();

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);


        }


        public RelayCommand AddProductCommand
        {
            get => new(() => { _navigateService.NavigateTo<AddProductViewModel>(); });
        }
       

        public RelayCommand AddCategoryCommand
        {
            get => new(() => { _navigateService.NavigateTo<AddCategoryViewModel>();});
        }
        public RelayCommand ToUserPage
        {
            get => new(() => { _navigateService.NavigateTo<HomeViewModel>(); });
        }
        
    }
}
