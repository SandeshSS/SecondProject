using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class Inventory
    {
        [Key]
        public int SlNo { get; set; }
        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int QtyInInventory { get; set; }
        public DateTime InventoryDate { get; set; }
        public bool IsInventoryActive { get; set; }
    }
}
