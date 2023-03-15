using AdminPanel.Messanger;
using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdminPanel.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        public Electronics Electronics { get; set; } = new();
        public DataBase DataBase { get; set; } = new();
        private readonly INavigateService _navigateService;
        private readonly IAdminService _adminService;
        private readonly IMessenger _messenger;
        public AddProductViewModel(IAdminService adminservice, INavigateService navigateService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _adminService = adminservice; 
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                Electronics = message.Data as Electronics;
            });

        }
       
        public RelayCommand SaveButton
        {
            get => new(() =>
            {
                //if (Electronics.CheckNulls() != null)
                //{
                //    DataBase.AllElectronics!.Add(_adminService.AddObject(Electronics));

                //    Serialize.FileService.Truncate("AllElectronics.json");

                //    _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.AllElectronics!, "AllElectronics.json");

                //    Electronics = new();
                //}
                //else
                //    MessageBox.Show("Заполните все поля!","Ошибка!",MessageBoxButton.OKCancel,MessageBoxImage.Error);

                if (Electronics.CheckNulls() != null)
                {
                    DataBase.ElectronicsList[Electronics.CategoryIndex]!.Add(_adminService.AddObject(Electronics));

                    if (DataBase.ElectronicsList[Electronics.CategoryIndex].Count > 1)
                        Serialize.FileService.Truncate(Electronics.Category + ".json");
                    
                    if (ID._id > 0)
                        Serialize.FileService.Truncate("ID.json");
                    
                    _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[Electronics.CategoryIndex]!, Electronics.Category + ".json");
                    IDService.SerializeID(Electronics.ProductID, "ID.json");

                    Electronics = new();
                }
                else
                    MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
