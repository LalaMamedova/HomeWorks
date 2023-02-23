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
    public partial class MainCashWindw : Window
    {
        public GasCollection gasCollection = new();
        public MiniMarket miniMarket = new();
        public int SelectedIndex;
        //public GesCollection GasCollection
        //{
        //    get => gasCollection; 
        //    set
        //    {
        //        gasCollection = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs("GasCollection"));
        //    }
        //}

        //public event PropertyChangedEventHandler? PropertyChanged;


        public MainCashWindw()
        {
            InitializeComponent();
        }

        private void GasChoice_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in gasCollection.gasStation)
                GasChoice.Items.Add(item.GasName);
            
            GasChoice.SelectedIndex = 0;
        }

        private void GasChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            priceTextBox.Text = gasCollection.gasStation[GasChoice.SelectedIndex].Price.ToString();
            SelectedIndex = GasChoice.SelectedIndex;
        }

        private void countRadioButton_Checked(object sender, RoutedEventArgs e) =>countTexBox.IsEnabled = true;
        private void SumRadioButton_Checked(object sender, RoutedEventArgs e) =>sumTextBox.IsEnabled = true;
        private void FantaCheckBox_Checked(object sender, RoutedEventArgs e) => fantaCountBox.IsEnabled = true;
          
        private void countRadioButton_Unchecked(object sender, RoutedEventArgs e) =>countTexBox.IsEnabled = false;
        private void SumRadioButton_Unchecked(object sender, RoutedEventArgs e)=>sumTextBox.IsEnabled = false;




        private void countTexBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(countTexBox.Text) && DataCheck.FloatCheck(countTexBox.Text) == true)
            {
                gasCollection.gasStation[SelectedIndex].Value = float.Parse(countTexBox.Text);
                float result = float.Parse(priceTextBox.Text) * float.Parse(countTexBox.Text);
                GasStationSum.Text = result.ToString() + " Манат";
            }
            else if (!string.IsNullOrEmpty(countTexBox.Text))
            {
                countTexBox.Text = countTexBox.Text.Remove(countTexBox.Text.Length - 1, 1);
                MessageBox.Show("Неправильные данные");
            }
            else
            {
                gasCollection.gasStation[SelectedIndex].Value = 0;
                GasStationSum.Text = "0";
            }
            
        }

        private void sumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(sumTextBox.Text) && DataCheck.FloatCheck(sumTextBox.Text))
            {
                float res = float.Parse(sumTextBox.Text) / gasCollection.gasStation[GasChoice.SelectedIndex].Price;
                countTexBox.Text = Math.Round(res, 2).ToString();
                GasStationSum.Text = "0";
            }
            else if (!string.IsNullOrEmpty(sumTextBox.Text))
                sumTextBox.Text = sumTextBox.Text.Remove(sumTextBox.Text.Length - 1, 1);
            else
                countTexBox.Text = "0";
        }

           
        
        private void CheckBoxes()
        {
            CheckBox[] allCheck = { potatoFriersCheckBox, FantaCheckBox, hamburgerCheckBox, hotDogCheckBox };
        }
        private void potatoFriersCheckBox_Checked(object sender, RoutedEventArgs e) =>potatoFriersCountBox.IsEnabled = true;
        private void hotDogCheckBox_Checked(object sender, RoutedEventArgs e)=> hoDogCountBox.IsEnabled = true;



        private void hotDogCheckBox_Unchecked(object sender, RoutedEventArgs e)=> hoDogCountBox.IsEnabled = false;
    }
}
