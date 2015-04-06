using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.Business
{
    internal class CustomerManager : ICustomerManager
    {
        private ICustomerRepository repository;

        public CustomerManager(IUnitOfWork uow)
        {
            repository = uow.GetCustomerRepository();
        }       

        public IList<Customer> GetCustomers()
        {            
            return repository.All().ToList<Customer>();
        }

        public void UpdateCustomer(Customer customer)
        {
            repository.Update(customer);
            repository.Save();
        }        
    }
}
