using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ToDo.Classes
{
    public class EnumBinding : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBinding(Type enumType)
        {
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
