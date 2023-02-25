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
            bool isFloat = float.TryParse(text, out float @float);

            if (isFloat) 
                return true;
            return false;

        }
        public static bool IntCheck(string text)
        {
            bool isInt = Int32.TryParse(text, out int isNumber);
            if (isInt)
                return true;
            return false;
        }
    }
}
