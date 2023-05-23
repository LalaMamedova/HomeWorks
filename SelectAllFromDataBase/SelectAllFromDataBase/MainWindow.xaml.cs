using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace SelectAllFromDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connect = new("Data Source=HP;Initial Catalog=BarberBase;Integrated Security=True;");
        public MainWindow() => InitializeComponent();
        

 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (connect.State != ConnectionState.Open)
            {
                connect.Open();
            }

            else if(connect.State == ConnectionState.Open)
                MessageBox.Show("База данных открыта");

            else
                MessageBox.Show("База данных закрыта");

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

        private string ResFromTable(string query)
        {
            using SqlDataReader reader = SelectFromThisTable(query);

            try
            {
                
                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                foreach (var column in reader.GetColumnSchema())
                {
                    sb.Append($"{column.ColumnName} \t ");
                }

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb2.Append(reader[i].ToString() + "\t");
                    }
                    sb2.Append("\n");
                }

                return sb.ToString() + "\n" + sb2.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

           
        }


        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            ResTextBlock.Text = ResFromTable("SELECT * FROM RATING");
        }

        private void MaxMin(string maxmin)
        {
            string query = $"SELECT {maxmin}(ServicePrice) FROM Service";

            try
            {
                SqlCommand command = new SqlCommand(query, connect);
                var reader = command.ExecuteScalar();

                ResTextBlock.Text = reader.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }
        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            MaxMin("MAX");
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            MaxMin("MIN");
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResTextBlock.Text = ResFromTable(QueryTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
