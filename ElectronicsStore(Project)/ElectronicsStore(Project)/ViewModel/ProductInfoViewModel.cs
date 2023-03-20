using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElectronicsStore_Project_.ViewModel
{
    public class ProductInfoViewModel: ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly IMessenger _messenger;
        private readonly INavigateService _navigationService;
        public string FullName { get => Electronic.Category + " " + Electronic.Name + " " + Electronic.Memory; }
        public string LeftCount { get => "Осталось " + Electronic.Count + " штук"; }

        public Electronic Electronic { get; set; } = new();
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public ProductInfoViewModel(INavigateService navigationService, IMessenger messenger)
        {
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                Electronic = (Electronic)message.Data;
            });

            _navigationService = navigationService;
        }

        public RelayCommand BackToCategory
        {
            get => new(() => { _navigationService.NavigateTo<SelectedCategoryProductsViewModel>(); });
        }


    }
}
