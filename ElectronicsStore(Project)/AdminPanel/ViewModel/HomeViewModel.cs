using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;

        public DataBase DataBase { get; set; } = new();
        //public Category Category { get; set; } = new();

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public HomeViewModel(INavigateService navigateService)
        {
            _navigateService = navigateService;
        }

        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        
        public RelayCommand<object> ToSelectedCategory
        {
            get => new(param =>
            {
                try
                {
                    if (param != null)
                    {
                        if(AllProductsViewModel.SortedByCategory.Count > 0)
                            AllProductsViewModel.SortedByCategory.Clear();

                        foreach (var item in DataBase.AllElectronics)
                        {
                            if (item.Category == param as string)
                                AllProductsViewModel.SortedByCategory.Add(item);
                        }
                        _navigateService.NavigateTo<AllProductsViewModel>(param);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }


    }
}
