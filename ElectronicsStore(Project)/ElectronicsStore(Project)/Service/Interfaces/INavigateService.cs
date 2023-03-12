using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Service.Interfaces
{
    public interface INavigateService
    {
        public void NavigateTo<T>() where T : ViewModelBase;

    }
}
