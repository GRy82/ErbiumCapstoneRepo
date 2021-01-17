using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IContractorRepository Contractor { get; }
        IJobRepository Job { get; }
        void Save();
    }
}
