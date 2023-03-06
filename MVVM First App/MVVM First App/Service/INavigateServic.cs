using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_First_App.Service
{
    public interface INavigateService
    {
        public void NavigateTo<T>() where T : ViewModelBase;

    }
}
