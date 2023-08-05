using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WhiteBoardProject.Class;
using System.Windows.Ink;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Net;
using System.Windows.Media.Animation;

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel : ViewModelBase,INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        private DrawingAttributes drawingAttributes = new();
        private InkCanvasEditingMode inkCanvasEditingMode = InkCanvasEditingMode.Ink;
        private SolidColorBrush selectedBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
  
        public ColorList ColorList { get; set; } = new();        
        public double Width { get; set; }
        public double Height { get; set; }

        public DrawingAttributes DrawingAttributes 
        {
            get => drawingAttributes;
            set { drawingAttributes = value; NotifyPropertyChanged(nameof(DrawingAttributes)); }
        }
        public SolidColorBrush SelectedBackGround
        {
            get => selectedBackGround; 
            set { selectedBackGround = value; NotifyPropertyChanged(nameof(SelectedBackGround)); }
        }
        public InkCanvasEditingMode InkCanvasEditingMode
        {
            get => inkCanvasEditingMode;
            set { inkCanvasEditingMode = value; NotifyPropertyChanged(nameof(InkCanvasEditingMode)); }
        }
        public ChangableObject isNightMode { get; set; } = new() { MyData = "Светлый" };
  


        public RelayCommand<string> ChoiceColor
        {
            get => new(param =>
            {
                InkCanvasEditingMode = InkCanvasEditingMode.Ink;
                DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(param);
            });
        }

        public RelayCommand Erase
        {
            get => new(() =>
            {
                InkCanvasEditingMode = InkCanvasEditingMode.EraseByPoint;
            });
        }

        public RelayCommand ChangeMode
        {
            get => new(() =>
            {
                if ((string)isNightMode.MyData == "Темный")
                {
                    SelectedBackGround.Color = ((Color)ColorConverter.ConvertFromString("White"));
                    isNightMode.MyData = "Светлый";
                }
                else
                {
                    SelectedBackGround.Color = ((Color)ColorConverter.ConvertFromString("Black"));
                    isNightMode.MyData = "Темный";

                }
            });
        }

 

    }

    

}
