using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public class TrollyOrderItem : BaseE
    {
        public string TrollyOrderId{get;set;}
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public int OrderQuantity { get; set; }

    }
}
