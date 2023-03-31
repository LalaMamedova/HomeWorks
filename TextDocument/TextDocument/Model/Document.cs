using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextDocument.Model
{
    public class Document : ICloneable, INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name = "Новый Документ";
        private int frontSize = 15;
        private string content = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length <= 25 && value.Length > 0)
                    name = value;

                else if(value.Length == 0)
                    MessageBox.Show("Введите название");

                else if (value.Length >25)
                    MessageBox.Show("Название слишком длинное");
            }
        }

        public string Content { get => content; set { content = value;} }

        [AlsoNotifyFor("FrontSize")]
        public int FrontSize { get => frontSize; set { frontSize = value; } }
        public bool IsRedacted { get; set; }
        public static int _id { get; set; } = 0;
        public int ID { get; set; } = _id;
        public Document()
        {
            _id += 1;
        }

        public object Clone() => new Document()
        {
            FrontSize = this.FrontSize,
        };



    }
}
