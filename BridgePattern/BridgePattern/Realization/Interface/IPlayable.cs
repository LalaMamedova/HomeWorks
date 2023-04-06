using BridgePattern.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Realization.Interface
{
    public interface IPlayable : ICharacther
    {
        public int CritDamage { get; set; }
        public int Strength { get; set; }
        public IWeapon Weapon {get;set;}
        public void Beat(ICharacther characther);
        public void UseUlt();
        public void SetWeapon(IWeapon weapon);

    }
}
