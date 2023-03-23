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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminPanel.View
{
    /// <summary>
    /// Interaction logic for MainAdminWindowView.xaml
    /// </summary>
    public partial class MainAdminWindowView : Window
    {
        bool check = false;
        public MainAdminWindowView()
        {
            InitializeComponent();
        }

        private void Minimilize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                this.WindowState = WindowState.Normal;
                MaximazeButton.Content = "▢";
                check = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaximazeButton.Content = "■";
                check = true;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e) => App.Current.Shutdown();

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)  =>this.DragMove();
        
    }
}
