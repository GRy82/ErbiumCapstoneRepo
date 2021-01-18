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
        public void CreateContractor(Contractor contractor) => Create(contractor);

        public Contractor GetContractor(int contractorId) =>
            FindByCondition(c => c.ContractorId.Equals(contractorId)).SingleOrDefault();

        public void EditContractor(Contractor contractor) => Update(contractor);

        public void DeleteContractor(Contractor contractor) => Delete(contractor);
    }
}
