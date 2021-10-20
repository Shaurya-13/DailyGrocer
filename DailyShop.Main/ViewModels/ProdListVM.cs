using DailyShop.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.ViewModels
{
    public class ProdListVM
    {
        
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProdCat> ProductCategories { get; set; }
    }
}
