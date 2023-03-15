using AdminPanel.Service.Classes;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Model
{
    public class ID
    {
        public int PersonalID { get; set; } = -1;
        public static int _id { get; private set; } 
        public ID(string path) 
        {
            var res = IDService.DesirializeID(path);
            if (res != null)
            {
                PersonalID = Int32.Parse(res);
                _id = PersonalID++;
            }
           
        }
    }
}
