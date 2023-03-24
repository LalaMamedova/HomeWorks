using ElectronicsStore_Project_.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ElectronicsStore_Project_.View
{
    /// <summary>
    /// Interaction logic for BankCardView.xaml
    /// </summary>
    public partial class BankCardView : Window
    {
        public BankCardView()
        {
            InitializeComponent();

            DataContext = App.Container.GetInstance<BankCardViewModel>();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
