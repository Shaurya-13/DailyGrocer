using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public class Trolly : BaseE
    {
        public virtual ICollection<TrollyItem> TrollyItems { get; set; }
        public Trolly() 
        {
            this.TrollyItems = new List<TrollyItem>();
        }
    }
}
