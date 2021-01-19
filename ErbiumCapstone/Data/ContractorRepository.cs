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
    public class ContractorRepository : RepositoryBase<Contractor>, IContractorRepository
    {
        public ContractorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreateContractor(Contractor contractor) => Create(contractor);

        public async Task<Contractor> GetContractorAsync(int contractorId) =>
            await FindByCondition(c => c.ContractorId.Equals(contractorId)).FirstOrDefaultAsync();

        public async Task<Contractor> GetContractorAsync(string contractorId) =>
            await FindByCondition(c => c.ContractorId.Equals(contractorId)).FirstOrDefaultAsync();

        public async Task<List<Contractor>> GetAllContractorsAsync() =>
            await FindAll().ToListAsync();



        public void EditContractor(Contractor contractor) => Update(contractor);

        public void DeleteContractor(Contractor contractor) => Delete(contractor);
    }
}
