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
using WhiteBoardProject.Service.Classes;
using ProjectLib.Model.Class;

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel : ViewModelBase, INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        private DrawingAttributes drawingAttributes = new();
        private InkCanvasEditingMode inkCanvasEditingMode = InkCanvasEditingMode.Ink;
        private SolidColorBrush selectedBackGround = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        private double width = 50;
        private double height = 50;
        private double textSize = 15;

        public ColorList ColorList { get; set; } = new();
        public StrokeCollection Stroke { get; set; } = new();
        public FigureSizeCollection FigureSizeCollection { get; set; } = new();
        public string WhatIsDrawing { get; set; }
        public double Width { get => width; set { width = value; drawingAttributes.Width = Width; NotifyPropertyChanged(nameof(Width)); } }
        public double Height { get => height; set { height = value; NotifyPropertyChanged(nameof(Height)); } }
        public DrawingAttributes DrawingAttributes { get => drawingAttributes; set { drawingAttributes = value; NotifyPropertyChanged(nameof(DrawingAttributes)); } }
        public SolidColorBrush SelectedBackGround { get => selectedBackGround; set { selectedBackGround = value; NotifyPropertyChanged(nameof(SelectedBackGround)); } }
        public InkCanvasEditingMode InkCanvasEditingMode { get => inkCanvasEditingMode; set { inkCanvasEditingMode = value; NotifyPropertyChanged(nameof(InkCanvasEditingMode)); } }
        public ChangableObject isNightMode { get; set; } = new() { MyData = "Светлый" };
        public Point MousePosition { get; set; } = new();
        public double TextSize { get => textSize; set { textSize = value; NotifyPropertyChanged(nameof(TextSize)); }}

        public RelayCommand<string> ChoiceColor
        {
            get => new(param =>
            {
                DrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(param);
            });
        }

       
        public RelayCommand Text
        {
            get => new(() =>
            {
                WhatIsDrawing = "None";
            });
        }
        public RelayCommand Erase
        {
            get => new(() =>
            {
                WhatIsDrawing = "None";
                InkCanvasEditingMode = InkCanvasEditingMode.EraseByPoint;
            });
        }
        public RelayCommand Select
        {
            get => new(() =>
            {
                WhatIsDrawing = "None";
                InkCanvasEditingMode = InkCanvasEditingMode.Select;
            });
        }

        public RelayCommand DrawWithPen
        {
            get => new(() =>
            {
                InkCanvasEditingMode = InkCanvasEditingMode.Ink;
                WhatIsDrawing = "None";
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

        public RelayCommand DrawCircle
        {
            get => new(() => {WhatIsDrawing = "Circle";});
        }
        public RelayCommand DrawDash
        {
            get => new(() => { WhatIsDrawing = "Dash";});
        }
        public RelayCommand DrawTriangle
        {
            get => new(() => {WhatIsDrawing = "Triangle";});
        }

        public RelayCommand DrawRectangle
        {
            get => new(() => {WhatIsDrawing = "Rectangle";});
        }



        public RelayCommand<InkCanvas> MouseMoveCommand
        {
            get => new((param) =>
            {

                MousePosition = Mouse.GetPosition(param);

                if (WhatIsDrawing == "Circle")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Circle(MousePosition, drawingAttributes, Width, Height));
                }
                else if (WhatIsDrawing == "Rectangle")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Rectangle(MousePosition, drawingAttributes, Width, Height));

                }
                else if (WhatIsDrawing == "Triangle")
                {
                    Stroke.Add(DrawService.Triangle(MousePosition, drawingAttributes, Width, Height));
                }
                else if (WhatIsDrawing == "Dash")
                {
                    InkCanvasEditingMode = InkCanvasEditingMode.None;
                    Stroke.Add(DrawService.Dash(MousePosition, drawingAttributes, Width, Height));
                }
                

            });
           
        }

    


        

    }

    

}
