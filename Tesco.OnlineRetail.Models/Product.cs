using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDesc { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]        
        public Category Category { get; set; }

        public bool IsActive { get; set; }
    }
}
