using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using GasStation.Classes;

namespace GasStation
{
    /// <summary>
    /// Interaction logic for MainCashWindw.xaml
    /// </summary>
    public partial class MainCashWindw : Window, INotifyPropertyChanged
    {
        private GesCollection gasCollection = new();
        public GesCollection GasCollection
        {
            get => gasCollection; 
            set
            {
                gasCollection = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GasCollection"));
            }
        }
        public MiniMarket miniMarket = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainCashWindw()
        {
            InitializeComponent();

        }

        private void GasChoice_Loaded(object sender, RoutedEventArgs e)
        {
            //GasChoice.Items.Add(gasCollection.gasStation[0].GasName);
            //GasChoice.Items.Add(gasCollection.gasStation[1].GasName);

        }

        private void CheckBoxHotDog_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
