using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DailyShop.Main.Models;

using DailyShop.Main.ViewModels;
using DailyShop.Main.Contracts;
using System.IO;

namespace DailyShop.UI.Controllers
{
    [Authorize(Users = "administrator@grocer.com")]
    public class ProductManagementController : Controller
    {
        IRepository<Product> context;
        IRepository<ProdCat> productCategories;
        public ProductManagementController(IRepository<Product> pContext, IRepository<ProdCat> pCatContext ) 
        {
            context = pContext;
            productCategories = pCatContext;
        }
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create() 
        {
            ProdManagerVM viewModel = new ProdManagerVM();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file) 
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else 
            {
                if (file != null) 
                {
                    product.Img = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProdImgUp//") + product.Img);
                }
                context.Insert(product);
                context.Save();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id) 
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else 
            {
                ProdManagerVM viewModel = new ProdManagerVM();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file) 
        {
            Product pToEdit = context.Find(Id);
            if (pToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                    if (file != null) 
                    {
                        pToEdit.Img = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProdImgUp//") + pToEdit.Img);
                    }
                    pToEdit.Cat = product.Cat;
                    pToEdit.Desc = product.Desc;
                    pToEdit.Name = product.Name;
                    pToEdit.Price = product.Price;

                    context.Save();

                    return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(String Id)
        {
            Product pToDel = context.Find(Id);
            if (pToDel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(pToDel);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDeleted(string Id) 
        {
            Product pToDel = context.Find(Id);
            if (pToDel == null)
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