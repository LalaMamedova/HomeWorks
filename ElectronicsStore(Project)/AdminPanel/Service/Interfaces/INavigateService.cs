using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Service.Interfaces
{
    public interface INavigateService
    {
        public object Data { get; set; }
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;

    }
}
