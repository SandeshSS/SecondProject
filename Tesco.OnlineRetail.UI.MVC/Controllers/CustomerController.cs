using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;
using Tesco.OnlineRetail.UI.MVC.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
namespace Tesco.OnlineRetail.UI.MVC.Controllers
    
{
    public class CustomerController : Controller
    {
        private ICustomerManager customerMgr = null;

        public CustomerController(ICustomerManager customerMgr)
        {
            this.customerMgr = customerMgr;
        }
        ManageLoginsViewModel mag = new ManageLoginsViewModel();

       
         //GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = customerMgr.GetCustomers().ToList<Customer>();           
            return View(customers);            
        }       
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update(Customer customer)
        {
            customerMgr.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}