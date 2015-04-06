using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Models;
using Tesco.OnlineRetail.Data.EFRepository;
using System.Net;
using System.Data.Entity;
using PagedList;


namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager ProductMgr = null;
        private ICategoryManager CategoryMgr = null;
        private EntityContextGroup1 db = new EntityContextGroup1();

        public ProductController(IProductManager ProductMgr, ICategoryManager CategoryMgr)
        {
            this.ProductMgr = ProductMgr;
            this.CategoryMgr = CategoryMgr;
        }

        public ActionResult Index(int? page)
        {
            List<Product> Products = ProductMgr.GetProducts().ToList<Product>();
            
          //  return View(Products);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            fetch();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Product> products = ProductMgr.GetProducts().ToList<Product>();
                    var values1 =
                    (from c in products
                     where c.ProductName == product.ProductName
                     select c).Count();

                    if (values1 <= 0)
                    {
                        
                        ProductMgr.SaveProduct(product);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = product.ProductName + " already exists";
                    }


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(product);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productInfo = db.Products.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }
        [HttpPost]
        public ActionResult Edit(Product productInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productInfo);
        }
        private void fetch()
        {
            var categories = CategoryMgr.GetCategories().ToList<Category>();
            IEnumerable<SelectListItem> values =
                from c in categories
                where c.IsActive = true
                select new SelectListItem
                {
                    Text = c.CategoryName.ToString(),
                    Value = c.CategoryId.ToString()
                };

            ViewBag.CategoryItems = values;
        }

        public ActionResult Details(int id)
        {
            Product productInfo = db.Products.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productInfo = db.Products.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product productInfo = db.Products.Find(id);
            db.Products.Remove(productInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}