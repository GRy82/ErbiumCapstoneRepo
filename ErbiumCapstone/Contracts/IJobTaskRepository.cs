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
        Task<JobTask> GetJobTaskAsync(int jobTaskId);

        Task<List<JobTask>> GetAllJobTasksAsync();

        Task<List<JobTask>> GetAllCurrentJobTasksAsync(List<Job> currentJobs);

        void EditJobTask(JobTask jobTask);
        void DeleteJobTask(JobTask jobTask);
    }
}
