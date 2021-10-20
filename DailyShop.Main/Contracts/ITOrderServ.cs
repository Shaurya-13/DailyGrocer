using DailyShop.Main.Models;
using DailyShop.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Contracts
{
    public interface ITOrderServ
    {
        void CreateOrder(TrollyOrder baseOrder, List<TrollyItemVM> trollyItems);
        List<TrollyOrder> GetOrderList();
        TrollyOrder GetOrder(string Id);
        void UpdateOrderStat(TrollyOrder updatedOrderStat);
    }
}
