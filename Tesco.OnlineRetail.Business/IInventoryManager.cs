using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public interface IInventoryManager
    {
        void AddQuantity(Inventory inventory);        
        IList<Inventory> GetInventory();       
        Inventory GetDetail(int id);
        void UpdateDetail(Inventory inventory);
    }
}
