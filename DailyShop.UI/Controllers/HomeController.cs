using DailyShop.DA.SQL;
using DailyShop.Main.Contracts;
using DailyShop.Main.Models;
using DailyShop.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyShop.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProdCat> productCategories;
        private GroceryShopContext db = new GroceryShopContext();
        public HomeController(IRepository<Product> pContext, IRepository<ProdCat> pCatContext)
        {
            context = pContext;
            productCategories = pCatContext;
        }
        public ActionResult Index(string Category=null) /*Works even when no category is passed in which is why null is used*/
        {
            List<Product> products;
            List<ProdCat> categories = productCategories.Collection().ToList();
            if (Category == null)
            {
                products=context.Collection().ToList(); 
            }
            else 
            {
                products = context.Collection().Where(p => p.Cat == Category).ToList();
            }
            ProdListVM model = new ProdListVM();
            model.Products = products;
            model.ProductCategories = categories;


            return View(model);
        }
        public ActionResult Search(string searchBy, string search) 
        {
            if (searchBy == "Cat")
            {
                return View(db.Products.Where(x => x.Cat == search || search == null).ToList());
            }
            else 
            {
                return View(db.Products.Where(x => x.Name.StartsWith(search)||search==null).ToList());
            }
            

        }

        public ActionResult Details(string id) 
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else 
            {
                return View(product);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}