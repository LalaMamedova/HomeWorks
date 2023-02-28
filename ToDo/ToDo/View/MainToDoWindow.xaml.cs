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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDo.View.Pages;
using ToDo.Classes;

namespace ToDo.View
{
    /// <summary>
    /// Interaction logic for MainToDoWindow.xaml
    /// </summary>
    public partial class MainToDoWindow : Window
    {
        public MainToDoWindow()
        {
            InitializeComponent();
        }

        private void ForHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ForHomePage();
        }

        private void ForWorkButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ForWork();
        }
    }
}
