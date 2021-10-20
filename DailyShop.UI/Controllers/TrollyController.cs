using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyShop.UI.Controllers
{
    public class TrollyController : Controller
    {
        IRepository<Consumer> consumers;
        ITrollyServ trollyServ;
        ITOrderServ tOrderServ;
        public TrollyController(ITrollyServ TrollyServ, ITOrderServ TOrderServ, IRepository<Consumer> Consumers) 
        {
            this.trollyServ = TrollyServ;
            this.tOrderServ = TOrderServ;
            this.consumers = Consumers;
        }
        // GET: Trolly
        public ActionResult Index()
        {
            var model = trollyServ.GetTrollyItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToTrolly(string Id) 
        {
            trollyServ.AddToTrolly(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromTrolly(string Id)
        {
            trollyServ.RemoveFromTrolly(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult TrollySummary() 
        {
            var trollySummary = trollyServ.GetTrollySum(this.HttpContext);

            return PartialView(trollySummary);
        }
        [Authorize]
        public ActionResult Checkout() 
        {
            Consumer consumer = consumers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);

            if (consumer != null)
            {
                TrollyOrder tOrder = new TrollyOrder()
                {
                    Email = consumer.Email,
                    City = consumer.City,
                    State = consumer.State,
                    FName = consumer.FName,
                    LName = consumer.LName
                };

                return View(tOrder);
            }
            else 
            {
                return RedirectToAction("Error");
            }
            
        }
        [HttpPost]
        [Authorize]
        public ActionResult Checkout(TrollyOrder trollyOrder) 
        {
            var trollyItems = trollyServ.GetTrollyItems(this.HttpContext);
            trollyOrder.TrollyOrderStatus = "Order successfully created";
            trollyOrder.Email = User.Identity.Name;

            //assuming Payment is processed
            trollyOrder.TrollyOrderStatus = "Payment authenticated Successfully";
            tOrderServ.CreateOrder(trollyOrder, trollyItems);
            trollyServ.CLearTrolly(this.HttpContext);


            return RedirectToAction("Thankyou", new { TrollyOrderId=trollyOrder.Id});
        }
        public ActionResult ThankYou(string TrollyOrderId) 
        {
            ViewBag.TrollyOrderId = TrollyOrderId;
            return View();
        }
    }
}