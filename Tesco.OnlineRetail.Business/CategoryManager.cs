using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    internal class CategoryManager : ICategoryManager
    {
        private ICategoryRepository repository = null;

        public CategoryManager(IUnitOfWork uow)
        {
            repository = uow.GetCategoryRepository();
        }
        public void SaveCategory(Models.Category category)
        {
            repository.Create(category);
        }
        public IList<Models.Category> GetCategories()
        {
            return repository.All().ToList<Category>();
        }
    }
}
