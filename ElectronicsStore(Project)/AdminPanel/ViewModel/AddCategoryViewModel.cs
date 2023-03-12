using AdminPanel.Model;
using AdminPanel.Service.Classes;
using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        private readonly IAdminService _adminService = new AdminService();
        private INavigateService _navigateService;

        public AddCategoryViewModel(INavigateService navigateService)
        {
            _navigateService = navigateService;
        }

        public RelayCommand SaveButton
        {
            get => new(() =>
            {
                var AllText = _adminService.FromFileToList<ObservableCollection<Category>>("AllCategory.json");

                if (AllText != null)
                {
                    DataBase.AllCategory = AllText;
                    FileStream fileStream = new("AllCategory.json", FileMode.Truncate);
                    fileStream.Close();

                    DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");
                }
                else
                {
                    DataBase.AllCategory.Add(_adminService.AddObject<Category>(Category));
                    _adminService.FromListToFile<ObservableCollection<Category>>(DataBase.AllCategory, "AllCategory.json");
                }
                
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
