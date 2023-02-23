using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GasStation.Classes
{
    public class GasCollection  
    {
        public List<Gas> gasStation = new();
        
        public GasCollection()
        {
            gasStation.Add(new Gas("A-76", 5.4f));
            gasStation.Add(new Gas("A-85", 8.6f));
            gasStation.Add(new Gas("A-92", 6.4f));

        }
        public GasCollection(List<Gas> gasStation)
        {
            this.gasStation = gasStation;
        }
       

    }
}
