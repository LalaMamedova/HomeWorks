using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
using TextDocument.Model;

namespace TextDocument.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public int SelectedIndex { get; set; }
        public ObservableCollection<Document> Documents { get; set; } = new();
        public Document Document { get; set; } = new();
        private bool IsPrevDelete = false;

        public MainView()
        {
            InitializeComponent();
            DocumentControl.ItemsSource = Documents;
            Documents.Add(Document);
        }

     

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var NewDocument = (Document)Document.Clone();
            Documents.Add(NewDocument);
            MainTextBox.Text = NewDocument.Content;
            SelectedIndex+=1;
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            SelectedIndex = (int)button.CommandParameter;

            foreach (var docs in Documents)
            {
                if (docs.ID == SelectedIndex)
                {
                    FonSizeBox.Text = docs.FrontSize.ToString();
                    MainTextBox.Text = docs.Content;
                    docs.IsRedacted = true;
                }
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            SelectedIndex = (int)button.CommandParameter;

            foreach (var docs in Documents)
            {
                if(docs.ID == SelectedIndex)
                {
                    Documents.Remove(docs);

                    for (int i = SelectedIndex; i < Documents.Count; i++)
                        Documents[i].ID = i;
                    
                    Document._id = Documents.Count;
                    break;
                    
                }
            }
        }


        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MainTextBox.Text))
            {
                Documents[SelectedIndex].Content = MainTextBox.Text;

            }
        }

     
    }
}
