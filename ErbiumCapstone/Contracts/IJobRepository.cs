using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IJobRepository : IRepositoryBase<Job>
    {
        void CreateJob(Job job);
        Task<Job> GetJobAsync(int jobId);
        void EditJob(Job job);
        void DeleteJob(Job job);
        Task<List<Job>> GetAllJobsAsync(int id, Type type);
        Task<List<Job>> GetAllCurrentJobsAsync(int id, Type type);
        Task<List<Job>> GetAllPostedJobsAsync(int id, Type type);
        Task<List<Job>> GetAllPastJobsAsync(int id, Type type);
    }
}
