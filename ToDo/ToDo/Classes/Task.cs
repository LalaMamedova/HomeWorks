using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Classes
{
    public class Task
    {
        public string? Discription { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public bool IsSelected { get; set; } = false;


        public Task(string? taskName, DateTime? date, bool ischeked)
        {
            Discription = taskName;
            Date = date;
            IsSelected = ischeked;
        }
      

        public Task()
        {
        }
        public override string ToString()
        {
            return Discription + " " + Date;
        }

    }
}
