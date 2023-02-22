using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GasStation.Classes
{
    public class GesCollection  
    {
        private List<Gas> gasStation = new();
        
        public GesCollection()
        {
            gasStation.Add(new Gas("A-76", 5.4f, 2f));
            gasStation.Add(new Gas("A-85", 8.6f, 3f));
        }
        public GesCollection(List<Gas> gasStation)
        {
            this.gasStation = gasStation;
        }

    }
}
