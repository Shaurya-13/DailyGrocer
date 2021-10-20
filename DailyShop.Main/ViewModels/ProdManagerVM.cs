using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyShop.Main.Models;

namespace DailyShop.Main.ViewModels
{
    public class ProdManagerVM
    {
        public Product Product { get; set; }
        public IEnumerable<ProdCat> ProductCategories { get; set; }
    }
}
