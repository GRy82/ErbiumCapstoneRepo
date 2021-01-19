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
        Contractor GetContractor(int contractorId);
        Contractor GetContractor(string contractorId);

        void EditContractor(Contractor contractor);
        void DeleteContractor(Contractor contractor);
    }
}
