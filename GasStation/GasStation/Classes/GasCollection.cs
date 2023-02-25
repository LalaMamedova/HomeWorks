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
            gasStation.Add(new Gas("Дизель", 0.3f));
            gasStation.Add(new Gas("A-92", 0.4f));
            gasStation.Add(new Gas("A-95", 1.5f));
            gasStation.Add(new Gas("А-88", 1.6f));
        }
        public GasCollection(List<Gas> gasStation)
        {
            this.gasStation = gasStation;
        }
       

    }
}
