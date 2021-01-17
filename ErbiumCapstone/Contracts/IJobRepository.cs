using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    interface IJobRepository : IRepositoryBase<Job>
    {
        void CreateJob(Job job);
        Job GetJob(int jobId);
        Job Update(int jobId);
        void Delete(int jobId);
    }
}
