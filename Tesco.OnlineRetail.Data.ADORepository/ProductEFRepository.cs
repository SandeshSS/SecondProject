using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;
using Tesco.OnlineRetail.Data.Repository;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    class ProductEFRepository:GenericRepository<Product>,IProductRepository
    {
    }
}
