using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IContractorRepository Contractor { get; }
        void Save();
    }
}
