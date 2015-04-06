using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;
using System.Web;
using Tesco.OnlineRetail.Data.EFRepository;

namespace Tesco.OnlineRetail.Business
{
    //sandesh
    internal class CartManager:ICartManager
    {
        private ICartItemRepository repository = null;
        private ICartRepository repositorycart = null;
        private IProductRepository repositoryproduct = null;
                
        public CartManager(IUnitOfWork uow)
        {
            repositorycart = uow.GetCartRepository();
            repository = uow.GetCartItemRepository();
            repositoryproduct = uow.GetProductRepository();
        }
        
        
         public void AddItem(CartItem item)
         {
             repository.Create(item);
         }
         public void AddToCart(Cart cart)
         {
             repositorycart.Create(cart);
         }
        public void UpdateItem(CartItem citem)
         {
             repository.Save();
            repository.Update(citem);

         }
        public void UpdateCart(Cart cart)
        {
            repositorycart.Save();
            repositorycart.Update(cart);
        }

        public CartItem GetItemsFromCartItem(int id)
        {
            CartItem citem = repository.Find(id);
            Product p = repositoryproduct.Find(citem.ProductId);
            citem.Product = p;
            return citem;
        }
        public Cart GetCartItems(int id)
        {
             Cart c= repositorycart.Find(id);
             CartItem citem = repository.Find(c.CartItemNo);
             Product p = repositoryproduct.Find(citem.ProductId);
             c.CartItem = citem;
             citem.Product = p;
             return c;
        }             
        
    }
}
