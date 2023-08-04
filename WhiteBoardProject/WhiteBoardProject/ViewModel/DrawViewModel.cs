using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WhiteBoardProject.Class;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace WhiteBoardProject.ViewModel
{
    public class DrawViewModel: ViewModelBase
    {
        public List<MyColor> AvailableColors { get; set; } = new()
        {
            new MyColor()
            {
                ColorName = "Оранжевый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange")),
            },
            new MyColor()
            {
                ColorName = "Красный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")),
            },

            new MyColor()
            {
                ColorName = "Синий",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue")),
            },
              new MyColor()
            {
                ColorName = "Розовый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink")),
            },  new MyColor()
            {
                ColorName = "Белый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White")),
            },  new MyColor()
            {
                ColorName = "Черный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
            },

               new MyColor()
            {
                ColorName = "Оранжевый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange")),
            },
            new MyColor()
            {
                ColorName = "Красный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")),
            },

            new MyColor()
            {
                ColorName = "Синий",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue")),
            },
              new MyColor()
            {
                ColorName = "Розовый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink")),
            },  new MyColor()
            {
                ColorName = "Белый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White")),
            },  new MyColor()
            {
                ColorName = "Черный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
            }, new MyColor()
            {
                ColorName = "Оранжевый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange")),
            },
            new MyColor()
            {
                ColorName = "Красный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")),
            },

            new MyColor()
            {
                ColorName = "Синий",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Blue")),
            },
              new MyColor()
            {
                ColorName = "Розовый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink")),
            },  new MyColor()
            {
                ColorName = "Белый",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White")),
            },  new MyColor()
            {
                ColorName = "Черный",
                ColorValue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black")),
            },
        };

   
        public static Brush ButtonColor { get; set; }


    }

    

}
