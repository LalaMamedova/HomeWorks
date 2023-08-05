using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WhiteBoardProject.Class
{
    public class ChangableObject: DependencyObject
    {
        public static readonly DependencyProperty MyDataProperty =
         DependencyProperty.Register("MyData", typeof(object), typeof(ChangableObject), new PropertyMetadata(null));

        public object MyData
        {
            get { return GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }
    }
}
