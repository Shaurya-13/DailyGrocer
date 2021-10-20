using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public class Product : BaseE
    {
        
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Desc { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Cat { get; set; }
        public string Img { get; set; }

    }
}
