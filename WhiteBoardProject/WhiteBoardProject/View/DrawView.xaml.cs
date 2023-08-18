using Humanizer;
using ProjectLib.Model.Class;
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
using WhiteBoardProject.Service.ClientService;
using WhiteBoardProject.ViewModel;
using static System.Net.Mime.MediaTypeNames;

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
        private void Myink_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox newTextBox = new TextBox();
                if (Myink.GetSelectedElements().FirstOrDefault().GetType().Name == nameof(TextBox))
                {
                    newTextBox = (TextBox)Myink.GetSelectedElements().FirstOrDefault();
                    newTextBox!.FontSize = SlidrWidth.Value;
                }
            }
            catch (Exception ex)
            {
            }
        }

        

        private void Myink_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Tab)
            {
                ColorPickerButton.IsChecked = !ColorPickerButton.IsChecked;
                ColorPickerPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
                e.Handled = true;

            }
            else if(e.Key == Key.LeftShift)
            {
                SizePickerButton.IsChecked = !SizePickerButton.IsChecked;
                SizePopupButton.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
                e.Handled = true;
            }

        }
    }
}
