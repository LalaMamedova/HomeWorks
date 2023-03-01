using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDo.Classes;
using Task = ToDo.Classes.Task;

namespace ToDo.View
{
    /// <summary>
    /// Interaction logic for AddTheTaskViewxaml.xaml
    /// </summary>
    public partial class AddTheTaskView : Window
    {
        private Task Task { get; set; }
     
        public AddTheTaskView()
        {
            InitializeComponent();
            Task = new();
            this.DataContext = Task;
            ImportanceBox.Items.Add("Неважно");
            ImportanceBox.Items.Add("Важно");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MainInfo.Text) || TaskTime.SelectedDate == null)
            {
                MessageBox.Show("Введите все поля!");
            }
            else
                this.Close();
        }

        public Task AddTask() 
        { 
            return Task;
        }
        

    }
}
