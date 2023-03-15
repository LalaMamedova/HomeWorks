using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.ViewModel
{
    internal class AddCategoryViewModel:ViewModelBase
    {      
        public Category Category { get; set; } = new();

        private readonly IAdminService _adminService;
        private readonly INavigateService _navigateService;
        private readonly IMessenger _messenger;

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

        public RelayCommand SaveButton
        {
            get => new(() =>
            {

                if (DataBase.AllCategory.Count > 0)//Проверка на наличие категорий
                {
                    if (_adminService.CkeckCategoryExist(Category)) //Существует ли такая категория
                    {
                        MessageBox.Show(Category.CategoryID.ToString());
                        
                        Serialize.FileService.Truncate("AllCategory.json");

                        DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                        _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");

                        Category = new();

                    }
                    else
                        MessageBox.Show("Уже существует");
                }

                else// Если категорий вообще нет, то добавляет первым без переписование файла
                {
                    DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");
                    Category = new();
                }
                
            });
        }

        public RelayCommand CancelButton
        { get => new(() =>
            {
                _navigateService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
