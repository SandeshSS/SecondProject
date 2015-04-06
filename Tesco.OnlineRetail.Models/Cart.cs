using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesco.OnlineRetail.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }    
       
        public int CartItemNo { get; set; }
        [ForeignKey("CartItemNo")]
        public CartItem CartItem { get; set; }

        public double TotalPrice { get; set; }
        public DateTime CartDate { get; set; }
    }
}
