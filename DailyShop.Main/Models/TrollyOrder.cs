using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public class TrollyOrder : BaseE
    {
        public TrollyOrder() 
        {
            this.TOrderItems = new List<TrollyOrderItem>();
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string TrollyOrderStatus { get; set; }
        public virtual ICollection<TrollyOrderItem> TOrderItems { get; set; }

    }
}
