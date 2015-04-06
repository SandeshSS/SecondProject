using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    public interface ICustomerManager
    {
        IList<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
    }
}
