using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Data
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        private object _repo;

        public JobRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
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
