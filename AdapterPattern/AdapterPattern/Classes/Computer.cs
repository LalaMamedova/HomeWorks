using AdapterPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Classes
{
    public class Computer
    {
        public List<USB> USB = new();
        public string CPU;
        public int RAM;

        public Computer(string cpu, int ram, params USB[] usb)
        {
            CPU = cpu;
            RAM = ram;
            InsertToUsb(usb);
        }

        public void InsertToUsb(params USB[] usb)
        {
            foreach (var usbItem in usb)
            {
                USB.Add(usbItem);
                Console.WriteLine(usbItem.GetType().Name + " был подключен к компьютеру");

            }

        }

    }
}
