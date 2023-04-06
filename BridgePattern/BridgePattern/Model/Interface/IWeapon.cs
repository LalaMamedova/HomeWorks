using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Model.Interface
{
    public interface IWeapon
    {
        public string WeaponName { get; set; }
        public int BaseAtack { get; set; }
    }
}
