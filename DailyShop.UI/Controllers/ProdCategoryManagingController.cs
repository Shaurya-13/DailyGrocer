using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DailyShop.Main.Models;

using DailyShop.Main.Contracts;

namespace DailyShop.UI.Controllers
{
    [Authorize(Users = "administrator@grocer.com")]
    public class ProdCategoryManagingController : Controller
    {
        // GET: ProdCategoryManaging
        IRepository<ProdCat> context;
        public ProdCategoryManagingController(IRepository<ProdCat> context)
        {
            this.context = context;
        }
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<ProdCat> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create()
        {
            ProdCat productCategory = new ProdCat();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProdCat productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Save();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            ProdCat productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProdCat productCategory, string Id)
        {
            ProdCat pCatToEdit = context.Find(Id);
            if (pCatToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                else
                {
                    pCatToEdit.CategoryName = productCategory.CategoryName;

                    context.Save();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(String Id)
        {
            ProdCat pCatToDel = context.Find(Id);
            if (pCatToDel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(pCatToDel);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDeleted(string Id)
        {
            ProdCat pCatToDel = context.Find(Id);
            if (pCatToDel == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Save();
                return RedirectToAction("Index");
            }
        }
    }
}