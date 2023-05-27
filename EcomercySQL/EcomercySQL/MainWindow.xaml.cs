using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace EcomercySQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connect = new();
        public ObservableCollection<Products> Products { get; set; } = new();
        public ObservableCollection<Category> Categorys { get; set; } = new();
        public ObservableCollection<Products> FilterProduct { get; set; } = new();


        public MainWindow() => InitializeComponent();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (connect.State != ConnectionState.Open)
            {
                connect.ConnectionString = ($"Data Source=HP;Initial Catalog=Ecommerce;Integrated Security=True;");

                connect.Open();
                SelectFromCategory();
                SelectFromProduct();    

            }

            else if (connect.State == ConnectionState.Closed)
                MessageBox.Show($"Ecommerce закрыта");
        }

        private SqlDataReader SelectFromThisTable(string query)
        {
            if (connect.State == ConnectionState.Open)
            {
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }

            throw new NotImplementedException();
        }

        private void SelectFromProduct()
        {
            using SqlDataReader reader = SelectFromThisTable($"Select * from Product");
            while (reader.Read())
            {
                Products.Add(new Products() 
                {
                    ID = (int)reader["Id"],
                    ProductName = (string)reader["ProductName"],
                    CategoryID = (int)reader["CategoryID"],
                    ImageLink = (string)reader["ImageLink"],
                    Quantity = (int)reader["Quantity"],
                    Price = (decimal)reader["Price"],
                });
               
            }
        }

        private void SelectFromCategory()
        {
            using SqlDataReader reader = SelectFromThisTable($"Select * from Category");
            while (reader.Read())
            {
                for (int i = 0; i < 1; i++)
                {
                    Categorys.Add(new Category() 
                    { 
                        ID = (int)reader["Id"],
                        CategoryName = (string)reader["CategoryName"],
                        ImageLink = (string)reader["ImageLink"]

                    });

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int productcount = Products.Count, index = 0;

            FilterProduct.Clear();

            for (int j = 0; j < Categorys.Count; j++)
            {
                if (Categorys[j].CategoryName == button.Content.ToString())
                {
                    index = j; break;
                }
            }

            for (int i = 0; i < productcount; i++)
            {
                if (Products[i].CategoryID == Categorys[index].ID)
                    FilterProduct.Add(Products[i]);
 
            }

            ProductListBox.ItemsSource = FilterProduct;
        }
    }
}
