using System;
using System.Collections;
using System.Collections.Generic;
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

namespace SelectAllFromDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connect = new();
        List<string> TablesName = new();
        public string DataBase { get; set; }

        public MainWindow() => InitializeComponent();
 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (connect.State != ConnectionState.Open)
            {
                connect.ConnectionString = ($"Data Source=HP;Initial Catalog={DataBase};Integrated Security=True;");
                try
                {
                    connect.Open();
                    MessageBox.Show($"{DataBase} данных открыта");

                    var tables = connect.GetSchema("Tables");

                    foreach (System.Data.DataRow row in tables.Rows)
                    {
                        string tableName = (string)row["TABLE_NAME"];
                        TablesName.Add(tableName);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Такой базы данных нет");
                }
            }

            else if(connect.State == ConnectionState.Closed)
                MessageBox.Show($"{DataBase} закрыта");

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
                
                StringBuilder tableName = new StringBuilder();
                StringBuilder rowName = new StringBuilder();

                foreach (var column in reader.GetColumnSchema())
                {
                    tableName.Append($"{column.ColumnName} \t ");
                }

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowName.Append(reader[i].ToString() + "\t");
                    }
                    rowName.Append("\n");
                }

                return tableName.ToString() + "\n" + rowName.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            ResTextBlock.Text = ResFromTable($"SELECT * FROM {TablesName[1]}");
        }

        private void MaxMin(string maxmin)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM {TablesName[0]}", connect);
            SqlDataReader reader = command.ExecuteReader();
            string randomSchema = string.Empty;

            foreach (var column in reader.GetColumnSchema())
            {
                randomSchema = ($"{column.ColumnName}");
                break;
            }

            string query = $"SELECT {maxmin}({randomSchema}) FROM Service";
            reader.Close();

            try
            {
                SqlCommand command2 = new SqlCommand(query, connect);
                var reader2 = command2.ExecuteScalar();

                ResTextBlock.Text = randomSchema + " " + reader2.ToString();
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
