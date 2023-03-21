using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Classes;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.ViewModel;

public class SelectedCategoryProductsViewModel : ViewModelBase
{
    private ViewModelBase? _currentViewModel;
    private readonly INavigateService _navigateService;
    private readonly IMessenger _messenger;
    public Electronic Electronic = new();
    public string CategoryDescription { get; set; } = DataBase.AllCategory[HomeViewModel.CategoryIndex].Description;
    public SearchService SearchService { get; set; } = new();
    public static ObservableCollection<Electronic> SortedByCategory { get; set; } = new();

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel!;
        set => Set(ref _currentViewModel, value);
       
    }
    public SelectedCategoryProductsViewModel(INavigateService navigateService, IMessenger messenger)
    {
        _navigateService = navigateService;
        _messenger = messenger;
    }

    public void ReceiveMessage(NavigationMessage message) => CurrentViewModel = (ViewModelBase)App.Container.GetInstance(message.ViewModelType);

    public RelayCommand BackToCategory
    {
        get => new(() => { _navigateService.NavigateTo<HomeViewModel>(); });
    }


    public RelayCommand<int> ToSelectedProduct
    {
        get => new(param =>
        {
            foreach (var item in SortedByCategory)
            {
                if (item.ID == param)
                {
                    Electronic = item;
                    _navigateService.NavigateTo<ProductInfoViewModel>(Electronic);

                }
            }
        });
    }

    public RelayCommand<int> ToBasketCommand
    {
        get => new(param =>
        {
            foreach (var item in SortedByCategory)
            {
                if (item.ID == param)
                    Electronic = item;
            }

            Basket basket = new Basket();
            basket.Electronic = Electronic;
            BasketService.AddToBasket(basket);
        });
    }

    public RelayCommand SearchCommand
    {
        get => new(() =>
        {
            int index = HomeViewModel.CategoryIndex;

            SearchService.SearchByName(index);
            SearchService.SearchByPrice(index);
            SearchService = new();

        });
    }

}
