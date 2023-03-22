using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Serialize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AdminPanel.ViewModel
{
    public class HomeViewModel:ViewModelBase
    {
        private ViewModelBase? _currentViewModel;
        private readonly INavigateService _navigateService;
        private readonly IAdminService _adminService;
        public DataBase DataBase { get; set; } = new();
        public static int CategoryIndex { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => Set(ref _currentViewModel, value);
        }
        public HomeViewModel(INavigateService navigateService, IAdminService admin)
        {
            _navigateService = navigateService;
            _adminService = admin;
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
        public RelayCommand<string> ChoiceImgButton
        {
            get => new(param =>
            {
                Indexdefinition(param);
                DataBase.AllCategory[CategoryIndex]!.IconPath = ImgServices.ImgChoice();
            });
        }
        public RelayCommand<string> ToSelectedCategory
        {
            get => new(param =>
            {
                try
                {
                    if (param != null)
                    {
                        Indexdefinition(param);
                        var res = _adminService.FromFileToList<ObservableCollection<Electronics>>(DataBase.AllCategory[CategoryIndex]?.CategoryName + ".json");

                        if (res != null)
                            DataBase.ElectronicsList[CategoryIndex] = res;

                        if (AllProductsViewModel.SortedByCategory.Count > 0)
                            AllProductsViewModel.SortedByCategory.Clear();

                        AllProductsViewModel.SortedByCategory = DataBase.ElectronicsList[CategoryIndex];

                        _navigateService.NavigateTo<AllProductsViewModel>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }


        public RelayCommand<string> DeleteCommand
        {
            get => new(param =>
            {
                Indexdefinition(param);

                DataBase.AllCategory!.Remove(DataBase.AllCategory.Where(x => x!.CategoryName == (string)param).Single());//Сингл ибо за одно нажатие я могу удалить лишь 1 категорию

                DataBase.ElectronicsList[CategoryIndex].Clear();
                
                File.Delete(param.ToString() + ".json");//Удаляю файл вообще
                Serialize.FileService.Truncate("AllCategory.json");

                _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory!, "AllCategory.json");
            });
        }

     
        public RelayCommand<string> RedactCommand
        {
            get => new(param =>
            {
                Indexdefinition(param );

                if (DataBase.ElectronicsList[CategoryIndex].Count > 0) 
                {
                    foreach (var item in DataBase.ElectronicsList[CategoryIndex])
                        item.Category = param;
                }

                var OldList = _adminService.FromFileToList<ObservableCollection<Category>>("AllCategory.json");
                string oldCategoryName = OldList[CategoryIndex].CategoryName;

                if (oldCategoryName != param)
                {
                    File.Move(oldCategoryName + ".json", param + ".json");//Меня название файла
                }
                Serialize.FileService.Truncate(param + ".json");
                _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[CategoryIndex], param + ".json");

                Serialize.FileService.Truncate("AllCategory.json");
                _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory!, "AllCategory.json");

            });
        }

        

    }
}
