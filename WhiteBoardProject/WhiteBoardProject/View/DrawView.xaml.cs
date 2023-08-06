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
        double size;
        Button senderButton;
        TextBox textBlock = new TextBox();
        private void DrawCircle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DrawDash_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void DrawTriangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }



        private void DrawRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DrawCircleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void DrawDashButton_Click(object sender, RoutedEventArgs e)
        {
            

        }
        private void DrawTriangleButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            //Myink.EditingMode = InkCanvasEditingMode.None;
            //Myink.MouseLeftButtonDown += DrawRectangle_MouseLeftButtonDown;

        }
        private void TextBoxButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var center = e.GetPosition(Myink);
            

            textBlock = new TextBox()
            {
                Text = "Пример текста",
                FontSize = size,
            };
            InkCanvas.SetLeft(textBlock, center.X);
            InkCanvas.SetTop(textBlock, center.Y);
            Myink.Children.Add(textBlock);
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
