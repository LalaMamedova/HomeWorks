using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        public static ObservableCollection<Electronics> SortedByCategory { get; set; } = new();
        public Electronics Electronics { get; set; } = new();

        public int Price { get; set; }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public AllProductsViewModel(INavigateService navigateService)
        {
            _navigateService = navigateService;
        }


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public RelayCommand BackToCategory
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<HomeViewModel>();
            });
        }
        public RelayCommand<object> MinPriceCommand
        {
            get => new(param =>
            {
                MessageBox.Show(Electronics.Price.ToString());

            });
        }

        public RelayCommand<object> DeleteCommand
        {
            get => new(param =>
            {
               MessageBox.Show(param.ToString());
            });
        }
    }
}
