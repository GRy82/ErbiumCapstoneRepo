using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IContractorRepository : IRepositoryBase<Contractor> //Class interface will contain methods unique to the model
    {
        
        void CreateContractor(Contractor contractor);
        Task<Contractor> GetContractorAsync(int contractorId);

        Task<Contractor> GetContractorAsync(string contractorId);

        Task<List<Contractor>> GetAllContractorsAsync();
        void EditContractor(Contractor contractor);
        void DeleteContractor(Contractor contractor);
    }
}
