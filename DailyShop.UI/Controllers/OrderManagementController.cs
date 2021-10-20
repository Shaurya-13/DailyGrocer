using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyShop.UI.Controllers
{
    [Authorize(Users = "administrator@grocer.com")]
    public class OrderManagementController : Controller
    {

        ITOrderServ orderServ;

        public OrderManagementController(ITOrderServ OrderServ) 
        {
            this.orderServ = OrderServ;
        }
        // GET: OrderManagement
        public ActionResult Index()
        {
            List<TrollyOrder> tOrders = orderServ.GetOrderList();
            return View(tOrders);
        }
        public ActionResult UpdateOrderStat(string Id) 
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order has been created",
                "Payment successfully processed",
                "Order has been Shipped",
                "Order Completed"
            };
            TrollyOrder tOrder = orderServ.GetOrder(Id);
            return View(tOrder);
        }
        [HttpPost]
        public ActionResult UpdateOrderStat(TrollyOrder updatedTOrder, string Id) 
        {
            TrollyOrder tOrder = orderServ.GetOrder(Id);
            tOrder.TrollyOrderStatus = updatedTOrder.TrollyOrderStatus;
            orderServ.UpdateOrderStat(tOrder);
            return RedirectToAction("Index");

        }
    }
}