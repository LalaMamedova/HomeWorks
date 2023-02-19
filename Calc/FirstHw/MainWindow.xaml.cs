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
            string? buttonClick = (string?)((Button)e.OriginalSource).Content;
            char? lastChar = null;

            if (!IsC(buttonClick) && buttonClick != "CE")
            {
                ResTextBox.Text += buttonClick;

                if (ResTextBox.Text.Length > 2)
                    lastChar = ResTextBox.Text[ResTextBox.Text.Length - 2];

                if (IsNumber(buttonClick))
                    currentNums += buttonClick;

                else if (IsMathSymbol(buttonClick) != null &&
                    IsMathSymbol(lastChar.ToString()) != null &&
                    IsMathSymbol(lastChar.ToString()) != IsMathSymbol(buttonClick))
                {
                    ResTextBox.Text = ResTextBox.Text.Replace(lastChar.ToString(), buttonClick);
                    ResTextBox.Text = ResTextBox.Text.Remove(ResTextBox.Text.Length - 1);
                }

                else if (IsMathSymbol(buttonClick) != null &&
                    IsMathSymbol(lastChar.ToString()) != null &&
                    IsMathSymbol(lastChar.ToString()) == IsMathSymbol(buttonClick))
                    ResTextBox.Text = ResTextBox.Text.Remove(ResTextBox.Text.Length - 1);

                else if (buttonClick == "=" && prevSymb != null)
                {
                    MathOperation();
                    ResTextBox.Text = "";
                    currentNums = "";
                    prevNum = null;
                    prevSymb = null;
                }

                else if (IsMathSymbol(buttonClick) != null && prevSymb != null)
                {
                    MathOperation();

                    ResTextBox.Text = ResLabel.Content.ToString() + buttonClick; // отображение на текстовом боксе
                    prevNum = Convert.ToDouble(ResLabel.Content.ToString());//предзначение
                    currentNums = "";//нового числа пока нет
                    prevSymb = buttonClick;// пред символом является то, что мы сейчас нажали
                }
             

                else if (IsMathSymbol(buttonClick) != null)
                {
                    prevSymb = buttonClick;
                    prevNum = Convert.ToDouble(currentNums);
                    currentNums = "";
                }
            }

            else if (IsC(buttonClick))
            {
                ResTextBox.Text = "";
                currentNums = "";
                prevNum = null;
                prevSymb = null;
            }
            else if (buttonClick == "CE")
            {
                ResTextBox.Text = ButtonCE(buttonClick, currentNums);
                currentNums = "";
            }
        }

        private double MathOperation()
        {
            if (prevSymb == "+")
                ResLabel.Content = prevNum + Convert.ToDouble(currentNums);
            else if (prevSymb == "-")
                ResLabel.Content = prevNum - Convert.ToDouble(currentNums);
            else if (prevSymb == "*")
                ResLabel.Content = prevNum * Convert.ToDouble(currentNums);
            else if (prevSymb == "/")
                ResLabel.Content = prevNum / Convert.ToDouble(currentNums);

            else if (prevSymb == "%")
            {
                ResLabel.Content = (prevNum * Convert.ToDouble(currentNums));
                ResLabel.Content = Convert.ToDouble(ResLabel.Content) / 100;
            }
            return Convert.ToDouble(ResLabel.Content);
        }
        private string? ButtonCE(string buttonClick,  string currentNums)
        {
            StringBuilder stringBuilder = new(ResTextBox.Text);
            stringBuilder.Remove(stringBuilder.Length - currentNums.Length, currentNums.Length);
            return stringBuilder.ToString();    
        }

        private bool IsNumber(string? symb) {
            char[] checkdigit = symb.ToCharArray();

            if (Char.IsDigit(checkdigit[0]) == true) 
                return true;
            return false;
        }


        private bool IsC(string symb)
        {
            if ( symb != "C")
                return false;
            return true;
        }


        private string? IsMathSymbol(string? symb)
        {
            if(symb == "+" || symb == "-"|| symb == "*" || symb == "/" || symb =="%")
                return symb;            
            return null;
        }

        private void ResLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResTextBox.Text = ResLabel.Content.ToString();
        }
    }
}
