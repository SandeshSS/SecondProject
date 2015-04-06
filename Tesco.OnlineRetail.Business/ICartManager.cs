using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public interface ICartManager
    {        
        void AddItem(CartItem item);
        void AddToCart(Cart cart);
        Cart GetCartItems(int id);
        void UpdateItem(CartItem citem);
        void UpdateCart(Cart cart);
        CartItem GetItemsFromCartItem(int id);
    }
}
