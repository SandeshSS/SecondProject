using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public ICustomerRepository GetCustomerRepository()
        {
            return new CustomerEFRepository();
        }
        public ICategoryRepository GetCategoryRepository()
        {
            return new CategoryEFRepository();
        }
        public IProductRepository GetProductRepository()
        {
            return new ProductEFRepository();
        }       
        public IInventoryRepository GetInventoryRepository()
        {
            return new InventoryEFRepository();
        }
        public ICartRepository GetCartRepository()
        {
            return new CartEFRepository();
        }
        public ICartItemRepository GetCartItemRepository()
        {
            return new CartItemEFRepository();
        }      
       
    }

}
