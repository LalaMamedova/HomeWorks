using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore_Project_.Model
{
    public class BankCard
    {
        public string? CardNumber { get; set; } = string.Empty;
        public string? UserCardType { get; set; } = string.Empty;
        public int UserCartTypeIndex { get; set; }
    }
}
