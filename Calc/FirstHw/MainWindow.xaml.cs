using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstHw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string? prevSymb ; 
        private string? currentNums;
        private double? prevNum;
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement item in MainGrid.Children)
            {
                if (item is Button)
                    ((Button)item).Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str != "C" && str != "CE")
            {
                ResTextBox.Text += str;

                if (str != "+" && str != "-" && str != "*" && str != "/" && str != "=")
                    currentNums += str;

                if (str == "+" || str == "-" || str == "*" || str == "/" || str == "=")
                {
                    ReplaceSymb(str);
                    Operations(str);
                    prevSymb = str;
                    prevNum = Convert.ToDouble(currentNums);
                    currentNums = null;
                }
            }

            else if (str == "C")
                Click_C();

            else if (str == "CE" && prevNum != null)
                ResTextBox.Text = ClickCE(ref currentNums);
            else
                Click_C();

        }
        private void Operations(string symbs)
        {
            if (prevSymb != null)
            {
                if (prevSymb == "+")
                    ResLabel.Content = prevNum + Convert.ToDouble(currentNums);
                if (prevSymb == "-")
                    ResLabel.Content = prevNum - Convert.ToDouble(currentNums);
                if (prevSymb == "*")
                    ResLabel.Content = prevNum * Convert.ToDouble(currentNums);
                if (prevSymb == "/")
                    ResLabel.Content = prevNum / Convert.ToDouble(currentNums);

                ResTextBox.Text = ResLabel.Content.ToString() + symbs;
                currentNums = ResLabel.Content.ToString();
                prevNum = null;
               
            }
        }

        private void ReplaceSymb(string newsymb)
        {
            char currentSymb = ResTextBox.Text[ResTextBox.Text.Count() - 1];
            char[] chararr = newsymb.ToCharArray();

            if (currentSymb == '+' || currentSymb == '*' || currentSymb == '-' || currentSymb == '/')
            {
                if (newsymb == "+" || newsymb == "-" || newsymb == "*" || newsymb == "/")
                {
                    ResTextBox.Text.Replace(currentSymb, chararr[0]);
                }
            }
        }

        private void ResBut_Click(string str)
        {
            if (prevNum != 0)
            {
                if (str == "+")
                    ResLabel.Content = prevNum + Convert.ToDouble(currentNums);
                if (str == "-")
                    ResLabel.Content = prevNum - Convert.ToDouble(currentNums);
                if (str == "*")
                    ResLabel.Content = prevNum * Convert.ToDouble(currentNums);
                if (str == "/")

                    ResLabel.Content = prevNum / Convert.ToDouble(currentNums);

                ResTextBox.Text = ResLabel.Content.ToString();
            }

            prevNum = Convert.ToDouble(currentNums);
            currentNums = null;
        }

        


        private string ClickCE(ref string str)
        {
            int removeLen = ResTextBox.Text.Count() -  str.Length;
            StringBuilder stringBuilder = new(ResTextBox.Text);
            stringBuilder.Remove(removeLen, str.Length);

            str = "";
            return stringBuilder.ToString();
            
        }
        private void Click_C() { ResTextBox.Text = ""; ResLabel.Content = ""; }

       

       
    }
}
