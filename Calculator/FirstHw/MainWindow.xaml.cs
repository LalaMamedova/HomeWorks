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

            if (buttonClick != "C" && buttonClick != "CE")//Если человек не стирает все
            {
                ResTextBox.Text += buttonClick;

                if (ResTextBox.Text.Length > 1)
                    lastChar = ResTextBox.Text[ResTextBox.Text.Length - 2];

                if (IsNumber(buttonClick)) //Если человек вводит числа
                    currentNums += buttonClick;

                currentNums = FirstNullCheck(currentNums);

                if (IsMathSymbol(buttonClick) != null &&//Если человек после нажатие на мат.символа нажал на другой/тот же мат.символ
                    IsMathSymbol(lastChar.ToString()) != null)
                {
                    if(IsMathSymbol(lastChar.ToString()) != IsMathSymbol(buttonClick) || IsMathSymbol(lastChar.ToString()) == IsMathSymbol(buttonClick))
                        ResTextBox.Text = ResTextBox.Text.Remove(ResTextBox.Text.Length - 2,1);
                }

                else if (buttonClick == "=" && currentNums == "")//Если человек нажал на "=" без второго значения
                    ResetEveryTring();

                else if (buttonClick == "=" && prevSymb != null)//Если человек нажал на "=" после обычной процедуры
                {
                    MathOperation();
                    ResetEveryTring();
                }

                else if (IsMathSymbol(buttonClick) != null && prevSymb != null)//Простое мат.операция
                {
                    MathOperation();

                    ResTextBox.Text = ResLabel.Content.ToString() + buttonClick;
                    prevNum = Convert.ToDouble(ResLabel.Content.ToString());
                    currentNums = "";
                    prevSymb = buttonClick;
                }

                else if (IsMathSymbol(buttonClick) != null)//Если человек нажал на мат.действия(+,- и прочее)
                {
                    prevSymb = buttonClick;
                    prevNum = Convert.ToDouble(currentNums);
                    currentNums = "";
                }
            }

            else if (buttonClick == "C")//очищает все
                ResetEveryTring();
            
            else if (buttonClick == "CE")//очищает последнее число
            {
                ResTextBox.Text = ButtonCE(buttonClick, ref currentNums);
                ResLabel.Content = "";
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
            else if (prevSymb == "²")
                ResLabel.Content = Math.Pow(Convert.ToInt32(prevNum), Convert.ToInt32(currentNums));
            else if (prevSymb == "%")
            {
                ResLabel.Content = (prevNum * Convert.ToDouble(currentNums));
                ResLabel.Content = Convert.ToDouble(ResLabel.Content) / 100;
            }
               
            return Convert.ToDouble(ResLabel.Content);
        }
        private string? ButtonCE(string buttonClick, ref string currentNums)
        {
            StringBuilder stringBuilder = new(ResTextBox.Text);
            stringBuilder.Remove(stringBuilder.Length - currentNums.Length, currentNums.Length);
            currentNums = "";
            return stringBuilder.ToString();    
        }

        private bool IsNumber(string? symb) {
            Regex intReg = new("[0-9,]");

            if (intReg.IsMatch(symb)) return true;
            return false;
        }

        private string? IsMathSymbol(string? symb)
        {
            if(symb == "+" || symb == "-"|| symb == "*" || symb == "/" || symb =="%" || symb == "²")
                return symb;            
            return null;
        }

        private void ResLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResTextBox.Text = ResLabel.Content.ToString();
            currentNums = ResLabel.Content.ToString();  
        }

        private void ResetEveryTring()
        {
            ResTextBox.Text  = ResTextBox.Text = null;
            currentNums = currentNums = null;
            prevNum = prevNum = null;
            prevSymb = prevSymb = null;
        }

        private string FirstNullCheck(string symbls)
        {
            if (!String.IsNullOrEmpty(symbls))
            {
                if (symbls[0] == '0')
                {
                    ResTextBox.Text = ResTextBox.Text.Remove(ResTextBox.Text.Length - currentNums.Length, currentNums.Length);
                    symbls = "";
                }
            }
            return symbls;
        }
    }
}
