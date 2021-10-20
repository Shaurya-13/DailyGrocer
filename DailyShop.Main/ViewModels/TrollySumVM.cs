using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.ViewModels
{
    public class TrollySumVM
    {
        public int TrollyCount { get; set; }
        public decimal TrollyTotal { get; set; }
        public TrollySumVM() 
        { 
        }
        public TrollySumVM(int trollyCount, decimal trollyTotal) 
        {
            this.TrollyCount = trollyCount;
            this.TrollyTotal = trollyTotal;
        }
    }
}
