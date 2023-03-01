using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes
{
    public class ToDoList
    {
        public ObservableCollection<Task> AllTasks { get; set; } = new();
        public ToDoList()
        {
            AllTasks.Add((new Task("Кино", false, DateTime.Parse("12.12.2022"), false)));
            AllTasks.Add((new Task("Пойти в кафе", true, DateTime.Parse("05.08.2010"), false)));
            AllTasks.Add((new Task("Купить мороженое", true, DateTime.Parse("08.06.2021"), true)));
           
        }

    }
}
