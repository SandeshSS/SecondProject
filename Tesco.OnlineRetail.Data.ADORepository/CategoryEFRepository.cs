using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    internal class CategoryEFRepository : GenericRepository<Category>, ICategoryRepository
    {
    }
}
