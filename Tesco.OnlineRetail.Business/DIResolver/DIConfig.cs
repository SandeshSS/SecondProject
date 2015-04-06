using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Data.EFRepository;
using Tesco.OnlineRetail.Business;
using System.Web.Mvc;

namespace Tesco.OnlineRetail.UI.MVC.App_Start
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel = null;
        public NinjectDependencyResolver()
        {
            this.kernel = new StandardKernel();
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            BindDependencies();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void BindDependencies()
        {
            kernel.Bind<ICustomerManager>().To<CustomerManager>();
            kernel.Bind<ICategoryManager>().To<CategoryManager>();
            kernel.Bind<IProductManager>().To<ProductManager>();
            kernel.Bind<ICartManager>().To<CartManager>();
            kernel.Bind<IInventoryManager>().To<InventoryManager>();
        }
    }
}