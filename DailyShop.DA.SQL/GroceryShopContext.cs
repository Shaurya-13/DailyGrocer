using DailyShop.Main.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.DA.SQL
{
    public class GroceryShopContext : DbContext
    {
        public GroceryShopContext()
            : base("DefaultConnection")  /*so we don't have to change the name of connectionString in web.config file*/
        {
             
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProdCat> ProdCategories { get; set; }
        public DbSet<Trolly> Trollys { get; set; }
        public DbSet<TrollyItem> TrollyItems { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<TrollyOrder> TOrders { get; set; }
        public DbSet<TrollyOrderItem> TOrderItem { get; set; }
    }
}
