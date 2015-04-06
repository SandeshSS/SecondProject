using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Data.EFRepository
{
    public class EntityContextGroup1 : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }       
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Cart { get; set; }       
    }
}
