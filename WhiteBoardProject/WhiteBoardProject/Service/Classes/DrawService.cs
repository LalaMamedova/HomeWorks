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
using ProjectLib.Model.Class;
using System.Windows.Media.Imaging;
using WhiteBoardProject.Service.ClientService;
using System.Windows.Media;

namespace WhiteBoardProject.Service.Classes
{
    public class DrawService:INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler? PropertyChanged;

        public static Stroke Circle(Point mousePosition, DrawingAttributes color, double width, double height, double angle)
        {
            double radius = Math.Min(width, height) / 2; // Радиус будет половиной минимальной стороны

            var points = new StylusPointCollection();

            for (int angleDegress = 0; angleDegress < 360; angleDegress++)
            {
                double radians = angleDegress * Math.PI / 180;
                double x = mousePosition.X + radius * Math.Cos(radians);
                double y = mousePosition.Y + radius * Math.Sin(radians);
                points.Add(new StylusPoint(x, y));
            }

            var stroke = new Stroke(points, new DrawingAttributes { Width = 8, Color = color.Color });
            return stroke;

        }
        public static Stroke Triangle(Point mousePosition, DrawingAttributes color, double width, double height, double angleDegrees)
        {
            var points = new StylusPointCollection();

            double angleRadians = angleDegrees * Math.PI / 180;
            double cos = Math.Cos(angleRadians);
            double sin = Math.Sin(angleRadians);

            double centerX = mousePosition.X;
            double centerY = mousePosition.Y;

            double x1 = centerX + (-width / 2) * cos - (-height / 2) * sin;
            double y1 = centerY + (-width / 2) * sin + (-height / 2) * cos;
            points.Add(new StylusPoint(x1, y1));

            double x2 = centerX + (width / 2) * cos - (-height / 2) * sin;
            double y2 = centerY + (width / 2) * sin + (-height / 2) * cos;
            points.Add(new StylusPoint(x2, y2));

            double x3 = centerX + (0) * cos - (height / 2) * sin;
            double y3 = centerY + (0) * sin + (height / 2) * cos;
            points.Add(new StylusPoint(x3, y3));

            double x4 = centerX + (-width / 2) * cos - (-height / 2) * sin;
            double y4 = centerY + (-width / 2) * sin + (-height / 2) * cos;
            points.Add(new StylusPoint(x4, y4));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 5, Color = color.Color });
            return stroke;
        }

        public static Stroke Dash(Point mousePosition, DrawingAttributes color, double width, double height, double angle)
        {
            double angleRadians = angle * Math.PI / 180;

            double endPointX = mousePosition.X + height * Math.Cos(angleRadians);
            double endPointY = mousePosition.Y + height * Math.Sin(angleRadians);

            var points = new StylusPointCollection();
            points.Add(new StylusPoint(mousePosition.X, mousePosition.Y));
            points.Add(new StylusPoint(endPointX, endPointY));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 2, Color = color.Color });

            return stroke;

        }

        public static Stroke Rectangle(Point mousePosition, DrawingAttributes color, double width, double height, double angle)
        {
            var points = new StylusPointCollection();

            double angleRadians = angle * Math.PI / 180;
            double cos = Math.Cos(angleRadians);
            double sin = Math.Sin(angleRadians);

            double centerX = mousePosition.X;
            double centerY = mousePosition.Y;

            double topLeftX = centerX + (-width / 2) * cos - (-height / 2) * sin;
            double topLeftY = centerY + (-width / 2) * sin + (-height / 2) * cos;

            double topRightX = centerX + (width / 2) * cos - (-height / 2) * sin;
            double topRightY = centerY + (width / 2) * sin + (-height / 2) * cos;

            double bottomRightX = centerX + (width / 2) * cos - (height / 2) * sin;
            double bottomRightY = centerY + (width / 2) * sin + (height / 2) * cos;

            double bottomLeftX = centerX + (-width / 2) * cos - (height / 2) * sin;
            double bottomLeftY = centerY + (-width / 2) * sin + (height / 2) * cos;

            points.Add(new StylusPoint(topLeftX, topLeftY));
            points.Add(new StylusPoint(topRightX, topRightY));
            points.Add(new StylusPoint(bottomRightX, bottomRightY));
            points.Add(new StylusPoint(bottomLeftX, bottomLeftY));
            points.Add(new StylusPoint(topLeftX, topLeftY));
            var stroke = new Stroke(points, new DrawingAttributes { Width = 3, Color = color.Color });

            return stroke;

        }

        public static Color PipetteColor(Point mousePosition, DrawingAttributes color, UserArt userArt)
        {
            int pixelX = (int)mousePosition.X;
            int pixelY = (int)mousePosition.Y;

            ArtService artService = new();
            BitmapSource imageSource = artService.FromByteToImage(userArt);

            CroppedBitmap croppedBitmap = new CroppedBitmap(imageSource, new Int32Rect(pixelX, pixelY, 1, 1));
            byte[] pixel = new byte[4];
            croppedBitmap.CopyPixels(pixel, 4, 0);

            return Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);
        }

        public static TextBox Text(Point mousePosition, DrawingAttributes color, double Width, double Height, double angle)
        {
            var center = mousePosition;

            TextBox textBox = new TextBox()
            {
                BorderThickness = new Thickness(0),
                Text = "Текст",
                FontSize = Width,
                Height = Height,
            };

            InkCanvas.SetLeft(textBox, center.X);
            InkCanvas.SetTop(textBox, center.Y);
            return textBox;

        }

    }
}
