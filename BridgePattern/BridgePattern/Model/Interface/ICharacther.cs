using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Model.Interface
{
    public interface ICharacther
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public void Run();//Потому, что даже NPC могут бежать(например бабулька из GTA SA
        public void Stay();
        public void Die();
    }
}
