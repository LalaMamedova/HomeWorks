using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Xps.Serialization;
using GasStation.Classes;

namespace GasStation
{
    /// <summary>
    /// Interaction logic for MainCashWindw.xaml
    /// </summary>
    public partial class MainCashWindw : Window
    {
        private readonly GasCollection _gasCollection = new();
        private MiniMarket _miniMarket = new();
        private int SelectedIndex;

        public MainCashWindw()
        {
            InitializeComponent();
        }

        #region GasStationPart

        private void GasChoice_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in _gasCollection.gasStation)
                GasChoice.Items.Add(item.GasName);
            GasChoice.SelectedIndex = 0;
        }

        private void GasChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            priceTextBox.Text = _gasCollection.gasStation[GasChoice.SelectedIndex].Price.ToString();
            SelectedIndex = GasChoice.SelectedIndex;
        }
     

        private void countRadioButton_Checked(object sender, RoutedEventArgs e) => countTexBox.IsEnabled = true;
        private void SumRadioButton_Checked(object sender, RoutedEventArgs e) => sumTextBox.IsEnabled = true;
        private void FantaCheckBox_Checked(object sender, RoutedEventArgs e) => fantaCountBox.IsEnabled = true;
        private void potatoFriersCheckBox_Checked(object sender, RoutedEventArgs e) => potatoFriersCountBox.IsEnabled = true;
        private void hotDogCheckBox_Checked(object sender, RoutedEventArgs e) => hoDogCountBox.IsEnabled = true;
        private void hamburgerCheckBox_Checked(object sender, RoutedEventArgs e) => hamburgerCountBox.IsEnabled = true;
        private void hamburgerCheckBox_Unchecked(object sender, RoutedEventArgs e) { hamburgerCountBox.IsEnabled = false; hamburgerCountBox.Text = "0"; }
        private void potatoFriersCheckBox_Unchecked(object sender, RoutedEventArgs e) { potatoFriersCountBox.IsEnabled = false; potatoFriersCountBox.Text = "0"; }
        private void FantaCheckBox_Unchecked(object sender, RoutedEventArgs e) { fantaCountBox.IsEnabled = false; fantaCountBox.Text = "0"; }
        private void hotDogCheckBox_Unchecked(object sender, RoutedEventArgs e) { hoDogCountBox.IsEnabled = false; hoDogCountBox.Text = "0"; }
        private void countRadioButton_Unchecked(object sender, RoutedEventArgs e) { countTexBox.IsEnabled = false; }
        private void SumRadioButton_Unchecked(object sender, RoutedEventArgs e) { sumTextBox.IsEnabled = false; }


        private void countTexBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(countTexBox.Text) && DataCheck.FloatCheck(countTexBox.Text) == true)
            {
                _gasCollection.gasStation[SelectedIndex].Value = float.Parse(countTexBox.Text);
                float result = float.Parse(priceTextBox.Text) * float.Parse(countTexBox.Text);
                GasStationSum.Text = Math.Round(result, 1).ToString();
            }
            else if(countTexBox.Text == "0" || countTexBox.Text == "")
            {
                _gasCollection.gasStation[SelectedIndex].Value = 0;
                GasStationSum.Text = "0";
            }
            else if (!string.IsNullOrEmpty(countTexBox.Text))
            {
                countTexBox.Text = countTexBox.Text.Remove(countTexBox.Text.Length - 1, 1);
                MessageBox.Show("Неправильные данные");
            }
            TotalSumma();
        }

        private void sumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(sumTextBox.Text) && DataCheck.FloatCheck(sumTextBox.Text))
            {
                float res = float.Parse(sumTextBox.Text) / _gasCollection.gasStation[GasChoice.SelectedIndex].Price;
                countTexBox.Text = Math.Round(res, 1).ToString();
            }
            else if (!string.IsNullOrEmpty(sumTextBox.Text))
            {
                sumTextBox.Text = sumTextBox.Text.Remove(sumTextBox.Text.Length - 1, 1);
                MessageBox.Show("Неправильные данные");
            }
            else
                countTexBox.Text = "0";
        }
        #endregion

        #region MarketPart

        private float PriceCount(string price, string count)
        {
            float newSum = 0;
            if (!string.IsNullOrEmpty(count) && DataCheck.IntCheck(count))
                newSum = float.Parse(price) * Convert.ToInt32(count);

            else if (!string.IsNullOrEmpty(count))
                MessageBox.Show("Введите данные правильно");

            return newSum;
        }

        private void MarketTotalSumCount()
        {
            float res = 0;
            if (CheckChanged(hotDogPrice.Text,0) && hoDogCountBox.Text != "")
                res += float.Parse(hotDogPrice.Text);

            if (CheckChanged(hamburgerPrice.Text, 1) && hamburgerCountBox.Text != "")
                res += float.Parse(hamburgerPrice.Text);

            if (CheckChanged(potatoFriersPrice.Text, 2) && potatoFriersCountBox.Text !="")
                res += float.Parse(potatoFriersPrice.Text);

            if (CheckChanged(fantaPrice.Text, 3) && fantaCountBox.Text != "")
                res += float.Parse(fantaPrice.Text);

            MarketSum.Text =Math.Round(res,1).ToString();
            TotalSumma();
        }
        private void InitializeAllPrice() 
        {
            hotDogPrice.Text = _miniMarket.Foods[0].Price.ToString();
            hamburgerPrice.Text = _miniMarket.Foods[1].Price.ToString();
            potatoFriersPrice.Text = _miniMarket.Foods[2].Price.ToString();
            fantaPrice.Text = _miniMarket.Foods[3].Price.ToString();
        }
        private void InitializeOnePrice(string FoodPrice, int index) => FoodPrice = _miniMarket.Foods[index].Price.ToString();
        

        private bool CheckChanged(string price,int index)
        {
            float convert = float.Parse(price);
            if (convert >= _miniMarket.Foods[index].Price) 
                return true;
             return false;
        }
        private void StackPanel_Loaded(object sender, RoutedEventArgs e) =>InitializeAllPrice();
        
        private void hoDogCountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hoDogCountBox.Text != "")
                hotDogPrice.Text = PriceCount(_miniMarket.Foods[0].Price.ToString(), hoDogCountBox.Text).ToString();
            else
                InitializeOnePrice(hotDogPrice.Text,0);
            MarketTotalSumCount();
        }

        private void hamburgerCountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hamburgerCountBox.Text != "")
                hamburgerPrice.Text = PriceCount(_miniMarket.Foods[1].Price.ToString(), hamburgerCountBox.Text).ToString();
            else
                InitializeOnePrice(hamburgerPrice.Text, 1);
            MarketTotalSumCount();
        }


        private void potatoFriersCountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (potatoFriersCountBox.Text != "")
                potatoFriersPrice.Text = PriceCount(_miniMarket.Foods[2].Price.ToString(), potatoFriersCountBox.Text).ToString();
            else
                InitializeOnePrice(potatoFriersPrice.Text, 2);
            MarketTotalSumCount();
        }

        private void fantaCountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fantaCountBox.Text != "")
                fantaPrice.Text = PriceCount(_miniMarket.Foods[3].Price.ToString(), fantaCountBox.Text).ToString();
            else
                InitializeOnePrice(fantaPrice.Text, 3);
            MarketTotalSumCount();

        }

        #endregion
        private void TotalSumma() => TotalSum.Content = float.Parse(GasStationSum.Text) + float.Parse(MarketSum.Text) + " Манат";
        private void PayButton_Click(object sender, RoutedEventArgs e)=> MessageBox.Show("ОПЛАТА ПРОШЛА УСПЕШНА!", "Платеж");

    }
}
