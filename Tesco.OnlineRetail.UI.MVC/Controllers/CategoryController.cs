using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Models;
using PagedList;

namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryManager categoryMgr = null;

        public CategoryController(ICategoryManager categoryMgr)
        {
            this.categoryMgr = categoryMgr;
        }



        // GET: Customer
        public ActionResult Index(int? page)
        {
            List<Category> categories = categoryMgr.GetCategories().ToList<Category>();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<Category> categories = categoryMgr.GetCategories().ToList<Category>();
                    var values1 =
                    (from c in categories
                     where c.CategoryName == category.CategoryName 
                     select c).Count();

                    if(values1 <= 0)
                    { 
                        category.IsActive = true;
                        categoryMgr.SaveCategory(category);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = category.CategoryName + " already exists";
                    }

                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(category); 
        }
    }
}