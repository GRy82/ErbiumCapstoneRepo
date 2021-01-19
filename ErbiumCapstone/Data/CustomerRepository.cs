using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using ErbiumCapstone.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Customer>> GetAllCustomersAsync() =>
            await FindAll().ToListAsync();

        public async Task<Customer> GetCustomerAsync(string userId) =>
           await FindByCondition(c => c.IdentityUserId.Equals(userId)).FirstOrDefaultAsync();

        public async Task<Customer> GetCustomerAsync(int customerId) =>
            await FindByCondition(c => c.CustomerId.Equals(customerId)).FirstOrDefaultAsync();

        public void EditCustomer(Customer customer) => Update(customer);
        public void DeleteCustomer(Customer customer) => Delete(customer);
        


    }
}
