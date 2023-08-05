using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WhiteBoardProject.ViewModel;

namespace WhiteBoardProject.View
{
    /// <summary>
    /// Interaction logic for DrawView.xaml
    /// </summary>
    public partial class DrawView : UserControl
    {
        public DrawView()
        {
            InitializeComponent();
        }
        bool isClick = true;
    
        private void DrawCircle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Myink.MouseLeftButtonDown -= DrawCircle_MouseLeftButtonDown;

            var center = e.GetPosition(Myink);
            var radius = 100;
            var points = new StylusPointCollection();

            for (int angle = 0; angle < 360; angle += 360 / 360)
            {
                double x = center.X + radius * Math.Cos(angle * Math.PI / 180);
                double y = center.Y + radius * Math.Sin(angle * Math.PI / 180);
                points.Add(new StylusPoint(x, y));
            }

            var stroke = new Stroke(points, new DrawingAttributes { Width = 8, Color = Myink.DefaultDrawingAttributes.Color });

            Myink.Strokes.Add(stroke);

        }

        private void DrawDash_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Myink.MouseLeftButtonDown -= DrawDash_MouseLeftButtonDown;

            var center = e.GetPosition(Myink);
            var points = new StylusPointCollection();
            points.Add(new StylusPoint(center.X, center.Y));

            double x = center.X + int.Parse(radius.Text); 
            double y = center.Y + int.Parse(radius2.Text);
            points.Add(new StylusPoint(x, y));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 8, Color = Myink.DefaultDrawingAttributes.Color });

            Myink.Strokes.Add(stroke);

        }

        private void DrawTriangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Myink.MouseLeftButtonDown -= DrawTriangle_MouseLeftButtonDown;

            var mousePosition = e.GetPosition(Myink);
            var points = new StylusPointCollection();

            double x1 = mousePosition.X; // Точка 
            double y1 = mousePosition.Y;
            points.Add(new StylusPoint(x1, y1));

            double x2 = mousePosition.X + int.Parse(radius.Text); // Вершина A
            double y2 = mousePosition.Y + int.Parse(radius2.Text);
            points.Add(new StylusPoint(x2, y2));


            double x3 = mousePosition.X - int.Parse(radius.Text); // Вершина B
            double y3 = mousePosition.Y + int.Parse(radius2.Text);
            points.Add(new StylusPoint(x3, y3));

            double x4 = mousePosition.X; // Вершина C
            double y4 = mousePosition.Y;
            points.Add(new StylusPoint(x4, y4));

            var stroke = new Stroke(points, new DrawingAttributes { Width = 5, Color = Myink.DefaultDrawingAttributes.Color });
            Myink.Strokes.Add(stroke);

        }



        private void DrawRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Myink.MouseLeftButtonDown -= DrawRectangle_MouseLeftButtonDown;

            var center = e.GetPosition(Myink);
            var points = new StylusPointCollection();
            double width = 80;
            double height = 80;

            double topLeftX = center.X - width / 2;
            double topLeftY = center.Y - height / 2;

            double topRightX = center.X + width / 2;
            double topRightY = center.Y - height / 2;

            double bottomRightX = center.X + width / 2;
            double bottomRightY = center.Y + height / 2;

            double bottomLeftX = center.X - width / 2;
            double bottomLeftY = center.Y + height / 2;

            points.Add(new StylusPoint(topLeftX, topLeftY));
            points.Add(new StylusPoint(topRightX, topRightY));
            points.Add(new StylusPoint(bottomRightX, bottomRightY));
            points.Add(new StylusPoint(bottomLeftX, bottomLeftY));
            points.Add(new StylusPoint(topLeftX, topLeftY)); 
            var stroke = new Stroke(points, new DrawingAttributes { Width = 3, Color = Myink.DefaultDrawingAttributes.Color });

            Myink.Strokes.Add(stroke);
        }

        private void DrawCircleButton_Click(object sender, RoutedEventArgs e)
        {
            Myink.EditingMode = InkCanvasEditingMode.None;
            Myink.MouseLeftButtonDown += DrawCircle_MouseLeftButtonDown;
            

        }
        private void DrawDashButton_Click(object sender, RoutedEventArgs e)
        {
            Myink.EditingMode = InkCanvasEditingMode.None;
            Myink.MouseLeftButtonDown += DrawDash_MouseLeftButtonDown;

        }
        private void DrawTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            Myink.EditingMode = InkCanvasEditingMode.None;
            Myink.MouseLeftButtonDown += DrawTriangle_MouseLeftButtonDown;

        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            Myink.EditingMode = InkCanvasEditingMode.None;
            Myink.MouseLeftButtonDown += DrawRectangle_MouseLeftButtonDown;

        }
    }
}
