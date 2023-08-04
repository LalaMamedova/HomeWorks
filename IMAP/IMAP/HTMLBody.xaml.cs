using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IMAP
{
    /// <summary>
    /// Interaction logic for HTMLBody.xaml
    /// </summary>
    public partial class HTMLBody : Window
    {
        public HTMLBody(string html)
        {
            InitializeComponent();
            WebBrowser.NavigateToString(html);
        }


    }
}
