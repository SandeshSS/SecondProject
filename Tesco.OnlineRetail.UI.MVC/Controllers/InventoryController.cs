using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Data.EFRepository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryManager inventoryMgr = null;
        private IProductManager ProductMgr = null;
        private EntityContextGroup1 db = new EntityContextGroup1();       

        public InventoryController(IInventoryManager inventoryMgr, IProductManager ProductMgr)
        {
            this.inventoryMgr = inventoryMgr;
            this.ProductMgr = ProductMgr;
        }
        // GET: Inventory
        public ActionResult Index()
        {
            List<Inventory> inventory = inventoryMgr.GetInventory().ToList<Inventory>();         
            return View(inventory);
        }
        
        public ActionResult Create()
        {
            fetch();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Inventory inventory)
        {
            try
            {
                if(ModelState.IsValid)
                {         
                    inventory.IsInventoryActive = true;
                    inventory.InventoryDate = DateTime.Now;
                   inventoryMgr.AddQuantity(inventory);
                   return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(inventory); 
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = inventoryMgr.GetDetail(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inv = inventoryMgr.GetDetail(id);
            inv.IsInventoryActive = false;
            inventoryMgr.UpdateDetail(inv);
            return RedirectToAction("Index");
        }


        
        private void fetch()
        {
            var products = ProductMgr.GetProducts().ToList<Product>();
            IEnumerable<SelectListItem> values =
                from p in products
                select new SelectListItem
                {
                    Text = p.ProductName.ToString(),
                    Value = p.ProductId.ToString()
                };

            ViewBag.ProductItems = values;
        }
    }
}