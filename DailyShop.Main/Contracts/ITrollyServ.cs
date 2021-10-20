using DailyShop.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DailyShop.Main.Contracts
{
    public interface ITrollyServ
    {
        void AddToTrolly(HttpContextBase httpContext, string productId);
        void RemoveFromTrolly(HttpContextBase httpContext, string itemId);
        List<TrollyItemVM> GetTrollyItems(HttpContextBase httpContext);
        TrollySumVM GetTrollySum(HttpContextBase httpContext);
        void CLearTrolly(HttpContextBase httpContext);
    }
}
