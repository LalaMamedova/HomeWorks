using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ElectronicsStore_Project_.ViewModel
{
    public class CheckViewModel:ViewModelBase
    {
        public  static ObservableCollection<Check> CheckList { get; set; } = new();
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        private readonly IMessenger _messenger;

        private Random randomNumbers = new();
      
        public CheckViewModel(INavigateService navigateService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
               
                if (message.Data.GetType().Name == typeof(ObservableCollection<Basket>).Name)
                {
                    Check newCheck = new();

                    foreach (var item in message.Data as ObservableCollection<Basket>)
                        newCheck.Basket.Add(item);
                    for (int i = 0; i < 5; i++)
                        newCheck.Barcode += randomNumbers.Next(1, 600).ToString();

                    newCheck.Price = newCheck.Basket.Sum(x => x.ThisElectronicPrice);
                    
                    CheckList.Add(newCheck);
                }
            });
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }


        public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

        public RelayCommand BackCommand
        {
            get => new(() => {_navigateService.NavigateTo<HomeViewModel>();});
        }
    }
}
