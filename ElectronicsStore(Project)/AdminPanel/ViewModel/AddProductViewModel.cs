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

namespace AdminPanel.ViewModel
{
    public class AddProductViewModel : ViewModelBase
    {
        public Electronics Electronics { get; set; } = new();
        public DataBase DataBase { get; set; } = new();
        private readonly IAdminService _adminService = new AdminService();
        private readonly INavigateService _navigateService;

        public AddProductViewModel(INavigateService navigateService)
        {
            _navigateService = navigateService;
        }

        public RelayCommand SaveButton
        {
            get => new(() =>
            {
                if (Electronics.CheckNulls() != null)
                {
                    DataBase.AllElectronics.Add(_adminService.AddObject(Electronics));

                    FileStream fileStream = new("AllElectronics.json", FileMode.Truncate);
                    fileStream.Close();
                    _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.AllElectronics, "AllElectronics.json");
                }
                else
                    MessageBox.Show("Заполните все поля!","Ошибка!",MessageBoxButton.OKCancel,MessageBoxImage.Error);
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
                _navigateService.NavigateTo<EmptyPanelViewModel>();
            });
        }
    }
}
