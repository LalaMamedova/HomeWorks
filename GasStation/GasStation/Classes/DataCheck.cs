using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GasStation.Classes
{
    public static class DataCheck
    {
        public static bool FloatCheck(string text)
        {
            Regex floatReg = new("[0-9,]");

            if(floatReg.IsMatch(text) == true && text.Contains('.') == false) return true;
            return false;

        }
        public static bool IntCheck(string text)
        {
            Regex intReg = new("[0-9]");
            if (intReg.IsMatch(text) == true) return true;
            return false;
        }
    }
}
