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
    public class CartController : Controller
    {
        private ICartManager cartMgr = null;
        private IInventoryManager invMgr = null;
        private IProductManager productMgr = null;
        private EntityContextGroup1 db = new EntityContextGroup1();

        public CartController()
        {

        }

        public CartController(ICartManager cartMgr,IInventoryManager invMgr,IProductManager productMgr)
        {
            this.cartMgr = cartMgr;
            this.invMgr = invMgr;
            this.productMgr = productMgr;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shipping()
        {
            return View();
        }
        [Authorize]
        public ViewResult AddToCart(int id)
        {
            
           GetProduct(id);
            return View("Index");
        }


        public ActionResult UpdateCart(int id, int qty,int price)
        {
            var inventory=invMgr.GetInventory().ToList<Inventory>();
            var cartitem = db.CartItems.ToList<CartItem>();
            var product = productMgr.GetProductsList().ToList<Product>();
            var v = (from m in inventory
                     join p in product on m.ProductId equals p.ProductId
                     select m.QtyInInventory
                         ).Sum();

            var v1 = (from m in inventory
                     join ca in cartitem on m.ProductId equals ca.ProductId
                     select ca.Quantity
                         ).Sum();

            if ((v1 + qty) >= v)
            {
                ViewBag.Message = "Out of Stock";
                Product p = db.Products.Find(id);
                return View("Index",p );
            }
            else
            {
                Cart objcart = new Cart();
                CartItem obj = new CartItem();     
                obj.ProductId = id;
                obj.Quantity = qty;
                cartMgr.AddItem(obj);
                objcart.CartItemNo = obj.CartItemNo;
                objcart.CartDate = DateTime.Now;
                objcart.TotalPrice = (double)qty * price;
                cartMgr.AddToCart(objcart);
                //int c=objcart.CartId;
                //return Redirect("/Shipping/Create/" + c);
                return View("Shipping");
            }
        }
        public ActionResult GetProduct(int id)
        {
            Product p = db.Products.Find(id);
            return View(p);
        }
        public ActionResult GetItems(int id)
        {           
            Cart cartobj = cartMgr.GetCartItems(id);            
             return View(cartobj);
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart c = cartMgr.GetCartItems(id);
            CartItem citem = cartMgr.GetItemsFromCartItem(id);
            if (c == null)
            {

                return HttpNotFound();
            }
            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart c = cartMgr.GetCartItems(id);
            CartItem citem = cartMgr.GetItemsFromCartItem(c.CartItemNo);
            //inventoryMgr.UpdateDetail(inv);
            db.CartItems.Remove(citem);
            db.SaveChanges();
            db.Cart.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult Create()
        {
            //AddToCart(1);
            return View();
        }
    }
}