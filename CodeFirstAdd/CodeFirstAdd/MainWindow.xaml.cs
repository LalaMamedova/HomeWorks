using CodeFirstAdd.Date.DataContext;
using CodeFirstAdd.Date.Models.Class;
using CodeFirstAdd.Models.Class;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

namespace CodeFirstAdd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClothingStoreContext Context { get; set; }
        public Category Category { get; set; } = new();
        public DataBase Database { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Context = new();
            foreach (var item in Context.Products)
                DataBase.Products.Add(item);
            
            foreach (var item in Context.Categories)
                DataBase.Categorys.Add(item);
         
        }

        private void UpdateProduct(IEnumerable<Product> newproduct)
        {
            DataBase.Products.Clear();
            foreach (var item in newproduct)
            {
                DataBase.Products.Add(item);
            }
            
        }

        private void UpdateCategory(IEnumerable<Category> newcategory)
        {
            DataBase.Categorys.Clear();
            foreach (var item in newcategory)
            {
                DataBase.Categorys.Add(item);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new(Context);
            addProduct.ShowDialog();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            UpdateProduct(Context.Products);

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
 

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct(Context.Products);
            UpdateCategory(Context.Categories);
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            Context.Categories.Add(Category);
            Context.SaveChanges();
            Category = new();
        }
    }
}
