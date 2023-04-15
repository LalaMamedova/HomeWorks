using AdapterPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Classes
{
    public class USBAdapter : USB
    {
        private List<IInsertable> insertable = new(5);
      
    
        public USB InsertISensertable(params IInsertable[] iInsertableobj)
        {
            insertable.AddRange(iInsertableobj);
            foreach (var i in insertable)
            {
                Console.WriteLine(i.GetType().Name + " подключен к USB адаптеру");
            }
           
            return this;
        }

    

        public USB Remove(int index)
        {
            if (insertable.Count > index)
            {
                Console.WriteLine(insertable[index].GetType().Name + " был отключен от USB Адаптера");
            }
            return this;

        }
    }
}
