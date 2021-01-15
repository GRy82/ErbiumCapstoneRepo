using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer> //Class interface will contain methods unique to the model
    {
        Customer GetCustomer(int customerId);
        void CreateCustomer(Customer customer);
    }
}
