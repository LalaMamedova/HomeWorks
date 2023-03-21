using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class Price:INotifyPropertyChanged
    {
        private float totalPrice;
        public event PropertyChangedEventHandler? PropertyChanged;
        public float TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                NotifyPropertyChanged(nameof(TotalPrice));
            }
        }

      
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Price(float startPrice)
        {
            totalPrice = startPrice;
            NotifyPropertyChanged(nameof(TotalPrice));

        }
    }
}
