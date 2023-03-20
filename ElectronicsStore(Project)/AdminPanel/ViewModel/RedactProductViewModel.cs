using AdminPanel.Model;
using AdminPanel.Service.Classes;
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
    public class RedactProductViewModel: ViewModelBase
    {
        public DataBase DataBase { get; set; } = new();
        public Electronics Electronics { get; set; } = new();
        private readonly INavigateService _navigateService;
        private readonly IAdminService _adminService;
        private readonly IMessenger _messenger;
        private int oldCategory;
        private int oldElectronicsIndex = 0;
        public RedactProductViewModel(IAdminService adminservice, INavigateService navigateService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _adminService = adminservice;
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                Electronics = message.Data as Electronics;

                if (Electronics != null)
                {
                    oldCategory = Electronics.CategoryIndex;

                    foreach (var item in DataBase.ElectronicsList[HomeViewModel.CategoryIndex])
                    {
                        if (item.ID == Electronics.ID) break;
                        
                        oldElectronicsIndex ++;
                    }
                    
                }
                
            });

        }

        public RelayCommand SaveCommand
        {
            get => new(() =>
            {
                int index = HomeViewModel.CategoryIndex;
                if (oldCategory != Electronics.CategoryIndex)
                {
                    var otherCategory = _adminService.FromFileToList<ObservableCollection<Electronics>>(DataBase.AllCategory[Electronics.CategoryIndex]?.CategoryName + ".json");

                    if (otherCategory != null)
                    {
                        DataBase.ElectronicsList[Electronics.CategoryIndex] = otherCategory;
                    }
                    
                    DataBase.ElectronicsList[index].RemoveAt(oldElectronicsIndex);

                    if (Electronics.CheckNulls() != null)
                    {
                        DataBase.ElectronicsList[Electronics.CategoryIndex].Add(Electronics);
                        Serialize.FileService.Truncate(Electronics.Category + ".json");
                        Serialize.FileService.Truncate(DataBase.AllCategory[oldCategory] + ".json");

                        //Переписываю данные старой категории
                        _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[Electronics.CategoryIndex]!, Electronics.Category + ".json");
                        //Переписывание данной новой категории
                        _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[index]!, DataBase.AllCategory[oldCategory] + ".json");

                    }
                }
                else
                {
                    Serialize.FileService.Truncate(Electronics.Category + ".json");
                    _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[index]!, DataBase.AllCategory[index] + ".json");
                }
                _navigateService.NavigateTo<HomeViewModel>();

            });

        }

        public RelayCommand ChoiceImgButton
        {
            get => new(() =>
            {
                Electronics.ImgPath = ImgServices.ImgChoice();
            });
        }

        public RelayCommand CancelButton
        {
            get => new(() =>
            {
                _navigateService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
