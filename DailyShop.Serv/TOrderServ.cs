using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using DailyShop.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Serv
{
    public class TOrderServ : ITOrderServ
    {
        IRepository<TrollyOrder> orderContext;
        public TOrderServ(IRepository <TrollyOrder> OrderContext) 
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(TrollyOrder baseOrder, List<TrollyItemVM> trollyItems)
        {
            foreach (var item in trollyItems) 
            {
                baseOrder.TOrderItems.Add(new TrollyOrderItem()
                {
                    ProductId=item.Id,
                    Img=item.Img,
                    Price=item.Price,
                    ProductName=item.ProductName,
                    OrderQuantity=item.ProdQuantity
                });
            }
            orderContext.Insert(baseOrder);
            orderContext.Save();
        }
        public List<TrollyOrder> GetOrderList() 
        {
            return orderContext.Collection().ToList();
        }
        public TrollyOrder GetOrder(string Id) 
        {
            return orderContext.Find(Id);
        }
        public void UpdateOrderStat(TrollyOrder updatedOrderStat) 
        {
            orderContext.Update(updatedOrderStat);
            orderContext.Save();
        }
    }
}
