using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WhiteBoardProject.Converters;
using WhiteBoardProject.Service.Classes;
using WhiteBoardProject.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace WhiteBoardProject.View
{
    /// <summary>
    /// Interaction logic for DrawView.xaml
    /// </summary>
    public partial class DrawView : UserControl
    {
        double size;
        Button senderButton;
        TextBox textBox;
        public DrawView()
        {
            InitializeComponent();
        }

        private void DrawCircle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {}
        private void DrawDash_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {}
        private void DrawTriangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {}
        private void DrawRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {}

        private void DrawCircleButton_Click(object sender, RoutedEventArgs e)
        {}
        private void DrawDashButton_Click(object sender, RoutedEventArgs e)
        {}
        private void DrawTriangleButton_Click(object sender, RoutedEventArgs e)
        {}

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            //Myink.EditingMode = InkCanvasEditingMode.None;
            //Myink.MouseLeftButtonDown += DrawRectangle_MouseLeftButtonDown;

        }
        private void TextBoxButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var center = e.GetPosition(Myink);

            textBox = new TextBox()
            {
                BorderThickness = new Thickness(0),
                Text = "Пример текста",
                FontSize = size,
            };
            InkCanvas.SetLeft(textBox, center.X);
            InkCanvas.SetTop(textBox, center.Y);
            Myink.Children.Add(textBox);
            Myink.MouseLeftButtonDown -= TextBoxButton_MouseLeftButtonDown;
        }
        private  void TextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            senderButton = (Button)sender;
            size = (double)senderButton.CommandParameter;

            Myink.EditingMode = InkCanvasEditingMode.None;
            Myink.MouseLeftButtonDown += TextBoxButton_MouseLeftButtonDown;
        }

    
        private void Myink_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox newTextBox = new TextBox();
                if (Myink.GetSelectedElements().FirstOrDefault().GetType().Name == newTextBox.GetType().Name)
                {
                    size = (double)senderButton.CommandParameter;
                    newTextBox = (TextBox)Myink.GetSelectedElements().FirstOrDefault();
                    newTextBox!.FontSize = SlidrWidth.Value;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
