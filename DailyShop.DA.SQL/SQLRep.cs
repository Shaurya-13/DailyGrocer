using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.DA.SQL
{
    public class SQLRep<P> : IRepository<P> where P : BaseE
    {
        internal GroceryShopContext context;
        internal DbSet<P> dbSet;

        public SQLRep(GroceryShopContext context) 
        {
            this.context = context;
            this.dbSet = context.Set<P>();
        }
        public IQueryable<P> Collection()
        {
            return dbSet;
        }

        public void Delete(string Id)
        {
            var p = Find(Id);
            if (context.Entry(p).State == EntityState.Detached) 
            {
                dbSet.Attach(p);
            }
            dbSet.Remove(p);
        }

        public P Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(P p)
        {
            dbSet.Add(p);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(P p)
        {
            dbSet.Attach(p);
            context.Entry(p).State = EntityState.Modified;
        }
    }
}
