using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    class ProductManager:IProductManager
    {
        private IProductRepository repository = null;

        public ProductManager(IUnitOfWork uow)
        {
            repository = uow.GetProductRepository();
        }
        public void SaveProduct(Product Product)
        {
            repository.Create(Product);
        }

        public IList<Product> GetProductsList()
        {
            return repository.All().ToList<Product>();
        }

        public IList<Product> GetProducts()
        {
            return repository.Get(p=>p.ProductId==p.ProductId,"Category").ToList<Product>();
        }
    }
}
