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
using ToDo.Classes;
using ToDo.Classes.SerializeService;
using Task = ToDo.Classes.Task;

namespace ToDo.View.Pages
{
    /// <summary>
    /// Interaction logic for ForWork.xaml
    /// </summary>
    public partial class ForWork : Page
    {
        public ObservableCollection<Task> TasksForWork { get; set; } = new();

        public ForWork()
        {
            InitializeComponent();

            if (FIleService.CheckFile("ForWork.json"))
            {
                TasksForWork = SerializeAndWrite.ReadAndDesiarile<ObservableCollection<Task>>("ForWork.json");
                TodoListBox.ItemsSource = TasksForWork;
            }
          
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            TasksForWork.RemoveAt(TodoListBox.SelectedIndex);
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddTheTaskView addTaskModel = new();

            addTaskModel.ShowDialog();
            TasksForWork.Add(addTaskModel.AddTask());

            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForWork.json", TasksForWork);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForWork.json", TasksForWork);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForWork.json", TasksForWork);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
