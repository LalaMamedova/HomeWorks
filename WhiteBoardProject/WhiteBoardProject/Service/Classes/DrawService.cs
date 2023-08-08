using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows;

namespace WhiteBoardProject.Service.Classes
{
    public class DrawService:INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        public static Stroke Circle(Point mousePosition, DrawingAttributes color, double Width, double Height)
        {
            var radius = Height + Width;
            var points = new StylusPointCollection();

            for (int angle = 0; angle < 360; angle += 360 / 360)
            {
                double x = mousePosition.X + radius * Math.Cos(angle * Math.PI / 180);
                double y = mousePosition.Y + radius * Math.Sin(angle * Math.PI / 180);
                points.Add(new StylusPoint(x, y));
            }

            var stroke = new Stroke(points, new DrawingAttributes { Width = 8, Color = color.Color });
            return stroke;

        }

        public static Stroke Triangle(Point mousePosition,DrawingAttributes color,double Width, double Height)
        {
            var points = new StylusPointCollection();

            double x1 = mousePosition.X; // Точка 
            double y1 = mousePosition.Y;
            points.Add(new StylusPoint(x1, y1));

            double x2 = mousePosition.X + Width; // Вершина A
            double y2 = mousePosition.Y + Height;
            points.Add(new StylusPoint(x2, y2));


            double x3 = mousePosition.X - Width; // Вершина B
            double y3 = mousePosition.Y + Height;
            points.Add(new StylusPoint(x3, y3));

            double x4 = mousePosition.X; // Вершина C
            double y4 = mousePosition.Y;
            points.Add(new StylusPoint(x4, y4));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 5, Color = color.Color });
            return stroke;

        }

        public static Stroke Dash(Point mousePosition, DrawingAttributes color, double Width, double Height)
        {
            var points = new StylusPointCollection();

            points.Add(new StylusPoint(mousePosition.X, mousePosition.Y));
            points.Add(new StylusPoint(mousePosition.X + Width, mousePosition.Y + Height));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 2, Color = color.Color });
            return stroke;

        }

        public static Stroke Rectangle(Point mousePosition, DrawingAttributes color, double Width, double Height)
        {
            var points = new StylusPointCollection();
            double width = 80;
            double height = 80;

            double topLeftX = mousePosition.X - width / 2;
            double topLeftY = mousePosition.Y - height / 2;

            double topRightX = mousePosition.X + width / 2;
            double topRightY = mousePosition.Y - height / 2;

            double bottomRightX = mousePosition.X + width / 2;
            double bottomRightY = mousePosition.Y + height / 2;

            double bottomLeftX = mousePosition.X - width / 2;
            double bottomLeftY = mousePosition.Y + height / 2;

            points.Add(new StylusPoint(topLeftX, topLeftY));
            points.Add(new StylusPoint(topRightX, topRightY));
            points.Add(new StylusPoint(bottomRightX, bottomRightY));
            points.Add(new StylusPoint(bottomLeftX, bottomLeftY));
            points.Add(new StylusPoint(topLeftX, topLeftY));
            var stroke = new Stroke(points, new DrawingAttributes { Width = 3, Color = color.Color });

            return stroke;

        }
        
        public static TextBox Text(Point mousePosition, DrawingAttributes color, double Width)
        {
            var center = mousePosition;

            TextBox textBox = new TextBox()
            {
                BorderThickness = new Thickness(0),
                Text = "Пример текста",
                FontSize = Width,
            };

            InkCanvas.SetLeft(textBox, center.X);
            InkCanvas.SetTop(textBox, center.Y);
            return textBox;

        }

    }
}
