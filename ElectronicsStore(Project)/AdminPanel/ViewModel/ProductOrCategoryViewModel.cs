using AdminPanel.Service.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdminPanel.ViewModel
{
    internal class ProductOrCategoryViewModel: ViewModelBase
    {
        private readonly INavigateService _navigationService;

        public ProductOrCategoryViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }

       
    }
}
