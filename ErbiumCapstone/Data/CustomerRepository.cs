using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private object _repo;

        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreateCustomer(Customer customer) => Create(customer);

        public Customer GetCustomer(int customerId) =>
            FindByCondition(c => c.CustomerId.Equals(customerId)).SingleOrDefault();

        public Customer Update(int customerId) =>
            FindByCondition(c => c.CustomerId.Equals(customerId)).SingleOrDefault();
        public void Delete(int customerId) =>
            FindByCondition(c => c.CustomerId.Equals(customerId)).SingleOrDefault();
        


    }
}
