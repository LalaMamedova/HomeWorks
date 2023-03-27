using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    internal class AddCategoryViewModel : ViewModelBase,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly IAdminService _adminService;
        private readonly INavigateService _navigateService;
        private readonly IMessenger _messenger;
        private Category category = new();

       
        public Category Category { 
            get => category; 
            set 
            { 
                category = value;
                NotifyPropertyChanged(nameof(Category)); 
            }
        }

        public AddCategoryViewModel(INavigateService navigateService, IAdminService adminService, IMessenger messenger)
        {
            _navigateService = navigateService;
            _adminService = adminService;
            _messenger = messenger;

            _messenger.Register<DataMessager>(this, message =>
            {
                if (message.Data.GetType().Name == typeof(Category).Name)
                    Category = (Category)message.Data;
            });
        }

      
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }


        public RelayCommand SaveButton
        {
            get => new(() =>
            {
                if (DataBase.AllCategory.Count > 0 && _adminService.CkeckCategoryExist(Category) && !Category.IsCategoryNull())
                {
                    Serialize.FileService.Truncate("AllCategory.json");

                    DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");

                    DataBase.ElectronicsList.Add(new());
                    Category = new();

                }

                else if (!Category.IsCategoryNull())
                {
                    DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");
                    Category = new();
                }
                else
                    MessageBox.Show("Заполните пустые поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                
            });
        }
        public RelayCommand ChoiceImgButton
        {
            get => new(() =>
            {
                Category.IconPath = ImgServices.ImgChoice();
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
