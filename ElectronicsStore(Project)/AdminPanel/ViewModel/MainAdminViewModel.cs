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
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    internal class MainAdminViewModel: ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private IAdminService _adminService = new AdminService();
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigateService;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

      
        private object? FillList(object list, string path)
        {
            var allItems = _adminService.FromFileToList<object>(path);
            if (allItems != null) return allItems!;
            return null;
        }

        public void ReceiveMessage(NavigationMessage message) =>CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public MainAdminViewModel(IMessenger messenger, INavigateService navigateService)
        {
            var allElectronics = _adminService.FromFileToList<ObservableCollection<Electronics>>("AllElectronics.json");
            if (allElectronics != null) DataBase.AllElectronics = allElectronics!;

            var allCategory = _adminService.FromFileToList<ObservableCollection<Category>>("AllCategory.json");
            if (allCategory != null) DataBase.AllCategory = allCategory!;

            CurrentViewModel = App.Container.GetInstance<HomeViewModel>();
          
            _messenger = messenger;
            _navigateService = navigateService;

            _messenger.Register<NavigationMessage>(this, ReceiveMessage);
        }


        public RelayCommand AddProductCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<AddProductViewModel>();
            });
        }


        public RelayCommand AddCategoryCommand
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<AddCategoryViewModel>();
            });
        }
        public RelayCommand ToUserPage
        {
            get => new(() =>
            {
                //if (DataBase.AllElectronics.Count == 0 && DataBase.AllCategory.Count == 0)
                //{
                //    var allElectronics = _adminService.FromFileToList<ObservableCollection<Electronics>>("AllElectronics.json");
                //    if (allElectronics != null) DataBase.AllElectronics = allElectronics!;

                //    var allCategory = _adminService.FromFileToList<ObservableCollection<Category>>("AllCategory.json");
                //    if (allCategory != null) DataBase.AllCategory = allCategory!;

                //    _navigateService.NavigateTo<HomeViewModel>();
                //}
                //else
                    _navigateService.NavigateTo<HomeViewModel>();

            });
        }
        
    }
}
