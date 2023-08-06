using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WhiteBoardProject.Class
{
    public class ColorList
    {
        public static List<CanvasColor> AvailableColors { get; set; } = new()
        {
            new CanvasColor()
            {
                ColorName = "Orange",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange")),
            },
            new CanvasColor()
            {
                ColorName = "Red",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")),
            },

            new CanvasColor()
            {
                ColorName = "Blue",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue")),
            },
              new CanvasColor()
            {
                ColorName = "Pink",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink")),
            },
            new CanvasColor()
            {
                ColorName = "White",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White")),
            },
            new CanvasColor()
            {
                ColorName = "Black",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
            },

            new CanvasColor()
            {
                ColorName = "Green",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green")),
            },
            new CanvasColor()
            {
                ColorName = "Purple",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Purple")),
            },
            new CanvasColor()
            {
                ColorName = "Yellow",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Yellow")),
            },
            new CanvasColor()
            {
                ColorName = "Cyan",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Cyan")),
            },
            new CanvasColor()
            {
                ColorName = "Brown",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Brown")),
            },
            new CanvasColor()
            {
                ColorName = "Gray",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gray")),
            },
            new CanvasColor()
            {
                ColorName = "Magenta",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Magenta")),
            },
            new CanvasColor()
            {
                ColorName = "Lime",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Lime")),
            }






        };
    }
}
