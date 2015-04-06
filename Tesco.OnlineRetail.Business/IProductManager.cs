using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public interface IProductManager
    {
        void SaveProduct(Product Product);
        IList<Product> GetProducts();
        IList<Product> GetProductsList();
    }
}
