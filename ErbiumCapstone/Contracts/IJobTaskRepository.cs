using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IJobTaskRepository : IRepositoryBase<JobTask>
    {
        void CreateJobTask(JobTask jobTask);
        JobTask GetJobTask(int jobTaskId);
        void EditJobTask(JobTask jobTask);
        void DeleteJobTask(JobTask jobTask);
    }
}
