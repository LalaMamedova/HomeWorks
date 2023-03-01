using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToDo.Classes.SerializeService;
using Task = ToDo.Classes.Task;
using ToDo.Classes;
using System.IO;

namespace ToDo.View.Pages
{
    /// <summary>
    /// Interaction logic for ForHomePage.xaml
    /// </summary>
    public partial class ForHomePage : Page
    {
        public ObservableCollection<Task> TasksForHome { get; set; } = new();
        private MainToDoWindow mainToDoWindow;
        public ForHomePage()
        {
            InitializeComponent();
        }
        public ForHomePage(MainToDoWindow mainntoDo)
        {
            InitializeComponent();
            mainToDoWindow = mainntoDo;

            //if (FIleService.CheckFile("ForHome.json"))
            //TasksForHome = SerializeAndWrite.ReadAndDesiarile<ObservableCollection<Task>>("ForHome.json");

            TasksForHome.Add((new Task("Кино", Importance.Важно, DateTime.Parse("12.12.2022"), false)));
            TasksForHome.Add((new Task("Пойти в кафе", Importance.Неважно, DateTime.Parse("05.08.2010"), false)));
            TasksForHome.Add((new Task("Купить мороженое", Importance.Важно, DateTime.Parse("08.06.2021"), true)));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            TasksForHome.RemoveAt(TodoListBox.SelectedIndex);
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            AddTheTaskView addTaskModel = new();

            addTaskModel.ShowDialog();
            TasksForHome.Add(addTaskModel.AddTask());

            //SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //SerializeAndWrite.WriteAndSerialize<ObservableCollection<Task>>("ForHome.json", TasksForHome);
        }
    }
}
