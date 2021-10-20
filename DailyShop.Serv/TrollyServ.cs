using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using DailyShop.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DailyShop.Serv
{
    public class TrollyServ : ITrollyServ
    {
        IRepository<Product> productContext;
        IRepository<Trolly> trollyContext;
        public const string TrollySessionName = "GrocerTrolly";
        public TrollyServ(IRepository<Product> ProductContext, IRepository<Trolly> TrollyContext) 
        {
            this.trollyContext = TrollyContext;
            this.productContext = ProductContext;
        }
        private Trolly GetTrolly(HttpContextBase httpContext, bool ifNull) 
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(TrollySessionName);
            Trolly trolly = new Trolly();
            if (cookie != null)
            {
                string trollyId = cookie.Value;
                if (!string.IsNullOrEmpty(trollyId))
                {
                    trolly = trollyContext.Find(trollyId);
                }
                else
                {
                    if (ifNull)
                    {
                        trolly = CreateNewTrolly(httpContext);
                    }
                }
            }
            else 
            {
                if (ifNull)
                {
                    trolly = CreateNewTrolly(httpContext);
                }
            }
            return trolly;
        }
        private Trolly CreateNewTrolly(HttpContextBase httpContext) 
        {
            Trolly trolly = new Trolly();
            trollyContext.Insert(trolly);
            trollyContext.Save();

            HttpCookie cookie = new HttpCookie(TrollySessionName);
            cookie.Value = trolly.Id;
            cookie.Expires = DateTime.Now.AddMonths(2);
            httpContext.Response.Cookies.Add(cookie);
            return trolly;
        }
        public void AddToTrolly(HttpContextBase httpContext, string productId) 
        {
            Trolly trolly = GetTrolly(httpContext, true);
            TrollyItem item = trolly.TrollyItems.FirstOrDefault(i =>i.ProductId==productId);
            if (item == null)
            {
                item = new TrollyItem()
                {
                    TrollyId = trolly.Id,
                    ProductId = productId,
                    ProdQuantity = 1
                };
                trolly.TrollyItems.Add(item);
            }
            else 
            {
                item.ProdQuantity = item.ProdQuantity + 1;
            }

            trollyContext.Save();
        }
        public void RemoveFromTrolly(HttpContextBase httpContext, string itemId) 
        {
            Trolly trolly = GetTrolly(httpContext,true);
            TrollyItem item = trolly.TrollyItems.FirstOrDefault(i => i.Id==itemId);
            if (item != null) 
            {
                trolly.TrollyItems.Remove(item);
                trollyContext.Save();
            }
        }
        public List<TrollyItemVM> GetTrollyItems(HttpContextBase httpContext) 
        {
            Trolly trolly = GetTrolly(httpContext, false);
            if (trolly != null)
            {
                var results = (from t in trolly.TrollyItems /* Used LINQ query to retrieve and join them from both product and trolly tables*/
                               join p in productContext.Collection() on t.ProductId equals p.Id
                               select new TrollyItemVM()
                               {
                                   Id = t.Id,
                                   ProdQuantity = t.ProdQuantity,
                                   Img = p.Img,
                                   Price = p.Price
                               }
                            ).ToList();
                return results;
            }
            else 
            {
                return new List<TrollyItemVM>();
            }
        }

        public TrollySumVM GetTrollySum(HttpContextBase httpContext) 
        {
            Trolly trolly = GetTrolly(httpContext, false);
            TrollySumVM model = new TrollySumVM(0,0);
            if (trolly != null)
            {
                int? trollyCount = (from item in trolly.TrollyItems /* ? mark used so in case trolly is empyt a null value can be shown or zero*/
                                    select item.ProdQuantity).Sum();
                decimal? trollyTotal = (from item in trolly.TrollyItems
                                        join p in productContext.Collection() on item.ProductId equals p.Id
                                        select item.ProdQuantity * p.Price).Sum();
                model.TrollyCount = trollyCount ?? 0; /* ?? is used so a definite value can be saved in the trolly count i.e., total items in it, "?? 0" means if trolly is empty then the value stored in trolly count would be 0*/
                model.TrollyTotal = trollyTotal ?? decimal.Zero;
                return model;
            }
            else 
            {
                return model;
            }
        }

        public void CLearTrolly(HttpContextBase httpContext) 
        {
            Trolly trolly = GetTrolly(httpContext, false);
            trolly.TrollyItems.Clear();
            trollyContext.Save();
        }
    }
}
