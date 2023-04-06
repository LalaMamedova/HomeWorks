using BridgePattern.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Model.Class.Weapon
{
    internal class Sword : IWeapon
    {
        public string WeaponName { get; set; }
        public int BaseAtack { get; set; }

    }
}
