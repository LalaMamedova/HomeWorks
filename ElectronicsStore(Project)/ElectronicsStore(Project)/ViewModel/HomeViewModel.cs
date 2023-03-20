using ElectronicsStore_Project_.Messanger;
using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.ViewModel
{
    public class HomeViewModel: ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        public DataBase DataBase { get; set; } = new();
        public static int CategoryIndex { get; set; }
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

        public void Indexdefinition(string param)
        {
            for (int i = 0; i < DataBase.AllCategory.Count; i++)
            {
                if (DataBase.AllCategory[i]!.CategoryName == param)
                {
                    CategoryIndex = i;
                    break;
                }
            }
        }
        public RelayCommand<object> ToSelectedCategory
        {
            get => new(param =>
            {
                try
                {
                    if (param != null)
                    {
                        Indexdefinition(param.ToString());

                        var json = FileService.Read(FilePath.path + DataBase.AllCategory[CategoryIndex].CategoryName + ".json");
                        if(json != null)
                            DataBase.ElectronicsList[CategoryIndex] = SerializeLibary.Deserialize<ObservableCollection<Electronic>>(json);


                        if (SelectedCategoryProductsViewModel.SortedByCategory.Count > 0)
                            SelectedCategoryProductsViewModel.SortedByCategory.Clear();

                        SelectedCategoryProductsViewModel.SortedByCategory = DataBase.ElectronicsList[CategoryIndex];

                        _navigateService.NavigateTo<SelectedCategoryProductsViewModel>(param);
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
