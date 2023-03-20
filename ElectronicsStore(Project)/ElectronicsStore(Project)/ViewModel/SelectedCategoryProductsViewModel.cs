using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
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


    public static ObservableCollection<Electronic> SortedByCategory { get; set; } = new();
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public string? ElectronicName { get; set; }

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

    public RelayCommand SearchCommand
    {
        get => new(() =>
        {
            int index = HomeViewModel.CategoryIndex;

            if (!string.IsNullOrEmpty(ElectronicName))
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Name != ElectronicName)
                    {
                        SortedByCategory.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (MinPrice > 0 || MaxPrice > 0)
            {
                for (int i = 0; i < DataBase.ElectronicsList[index].Count; i++)
                {
                    if (DataBase.ElectronicsList[index][i].Price > MaxPrice && DataBase.ElectronicsList[index][i].Price > MinPrice)
                    {
                        SortedByCategory.RemoveAt(i);
                        i--;
                    }
                }
            }
        });
    }

}
