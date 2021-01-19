using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer> //Class interface will contain methods unique to the model
    {
        void CreateCustomer(Customer customer);

        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerAsync(string customerId);
        Task<Customer> GetCustomerAsync(int customerId);
        void EditCustomer(Customer customer); 
        void DeleteCustomer(Customer customer);

    }
}
