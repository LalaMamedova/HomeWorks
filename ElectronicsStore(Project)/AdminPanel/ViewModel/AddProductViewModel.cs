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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdminPanel.ViewModel
{
    public class AddProductViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigateService _navigateService;
        private readonly IAdminService _adminService;
        private readonly IMessenger _messenger;
        private Electronics electronics = new();
        
        public static int _id { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public DataBase DataBase { get; set; } = new();
        public Electronics Electronics 
        { 
            get => electronics; 
            set { electronics = value; NotifyPropertyChanged();
            } 
        }
        public AddProductViewModel(IAdminService adminservice, INavigateService navigateService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _adminService = adminservice;
            _messenger = messenger;
            _id = IDService.DesirializeID("ID.json");


            _messenger.Register<DataMessager>(this, message =>
            {
                var category = message.Data as Category;
                Electronics.Category = category.CategoryName;
                Electronics.CategoryIndex = HomeViewModel.CategoryIndex;
            });
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand SaveButton
        {
            get => new(() =>
            {
                if (Electronics.CheckNulls() != null)
                {
                    Electronics.ID = _id;
                    DataBase.ElectronicsList[Electronics.CategoryIndex]!.Add(Electronics);

                    if (DataBase.ElectronicsList[Electronics.CategoryIndex].Count > 1)
                        Serialize.FileService.Truncate(Electronics.Category + ".json");

                    _adminService.FromListToFile<ObservableCollection<Electronics>>(DataBase.ElectronicsList[Electronics.CategoryIndex]!, Electronics.Category + ".json");

                    _id++;
                    IDService.SerializeID(_id, "ID.json");

                    Electronics = new()
                    {
                        CategoryIndex = HomeViewModel.CategoryIndex,
                        Category = DataBase.AllCategory[HomeViewModel.CategoryIndex].CategoryName,
                    };
               
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
