using FiltrationOnEntity.Models.Class;
using FiltrationOnEntity.Models.Context;
using FiltrationOnEntity.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Views.FiltrationOnEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EcommerceContext connection = new EcommerceContext();
        public DataBase DataBase { get; set; } = new();
        public int CountQuery { get; set; }

        private bool OrderByCount = false;
        private bool OrderByPrice = false;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Product product in connection.Products)
                DataBase.Products.Add(product);

            foreach (Category category in connection.Categories)
                DataBase.Categorys.Add(category);
        }


        private void SelectCount_Click(object sender, RoutedEventArgs e)
        {
            var query = connection.Products.Take(CountQuery);
            DataBase.Products.Clear();

            if (CountQuery <= connection.Products.Count())
            {
                foreach (var item in query)
                {
                    DataBase.Products.Add(item);
                }
            }
            else
                MessageBox.Show($"Товаров к сожалению меньше {CountQuery} ");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddView Add = new AddView();
            Add.ShowDialog();
            
        }

       
        private void Update(IEnumerable<Product> newproduct)
        {
            DataBase.Products.Clear();

            foreach (Product product in newproduct)
            {
                DataBase.Products.Add(product);
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update(connection.Products);
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Update(connection.Products);

            int productcount = DataBase.Products.Count, index = 0;


            for (int j = 0; j < DataBase.Categorys.Count; j++)
            {
                if (DataBase.Categorys[j].CategoryName == button.Content.ToString())
                {
                    index = j; break;
                }
            }


            for (int i = 0; i < productcount; i++)
            {
                if (DataBase.Products[i].CategoryId != DataBase.Categorys[index].Id)
                {
                    DataBase.Products.RemoveAt(i);
                    productcount--;
                    i--;
                }
            }
        }

        private void PriceSort_Click(object sender, RoutedEventArgs e)
        {
      
            IEnumerable<Product> query;

            if (OrderByCount == false)
            {
                query = connection.Products.OrderByDescending(x => x.Price);
                OrderByCount = true;
            }
            else
            {
                query = connection.Products.OrderBy(x => x.Price);
                OrderByCount = false;
            }
            Update(query);

        }

        private void CountSort_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> query;

            if (OrderByCount == false)
            {
                query = connection.Products.OrderByDescending(x => x.Quantity);
                OrderByCount = true;
            }
            else
            {
                query = connection.Products.OrderBy(x => x.Quantity);
                OrderByCount = false;

            }

            Update(query);

        }
    }
}
