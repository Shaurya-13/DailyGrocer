using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public class TrollyItem : BaseE
    {
        public string TrollyId { get; set; }
        public string ProductId { get; set; }
        public int ProdQuantity { get; set; }

    }
}
