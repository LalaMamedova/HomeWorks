using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.Model
{
    public class Basket : INotifyPropertyChanged
    {
        private float thisElectronicPrice;
        private int thisElectronicCount = 1;

        public event PropertyChangedEventHandler? PropertyChanged;


        public Electronic Electronic { get; set; } = new();
        public int ThisElectronicCount 
        { 
            get => thisElectronicCount;
            set { thisElectronicCount = value;  NotifyPropertyChanged(nameof(ThisElectronicCount));}
        }


        public float ThisElectronicPrice
        {
            get => thisElectronicPrice = Electronic.Price * ThisElectronicCount;
            set { thisElectronicPrice = value; NotifyPropertyChanged(nameof(ThisElectronicPrice)); }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       

    }
}
