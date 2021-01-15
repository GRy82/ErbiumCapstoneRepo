using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Repositories
{
    public class ContractorRepository : RepositoryBase<Contractor>, IContractorRepository
    {
        public ContractorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
