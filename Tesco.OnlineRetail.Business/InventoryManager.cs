using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    internal class InventoryManager : IInventoryManager
    {
        private IInventoryRepository repository;
        
        public InventoryManager(IUnitOfWork uow)
        {
            repository = uow.GetInventoryRepository();
        }

        public void AddQuantity(Inventory inventory)
        {
            repository.Create(inventory);
        }

        public void UpdateQuantity(Inventory inventory)
        {
            repository.Save();
            repository.Update(inventory);
        }

        public IList<Inventory> GetInventory()
        {
            return repository.Get(i=>i.SlNo==i.SlNo,"Product").ToList<Inventory>();
        }

        public Inventory GetDetail(int id)
        {
            return repository.Find(id);
        }

        public void UpdateDetail(Inventory inventory)
        {
            repository.Save();
            repository.Update(inventory);
        }
    }
}
