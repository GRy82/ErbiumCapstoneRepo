using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Data
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        private object _repo;

        public JobRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public void CreateJob(Job job) => Create(job);

        public async Task<Job> GetJobAsync(int jobId) =>
            await FindByCondition(c => c.JobId.Equals(jobId)).FirstOrDefaultAsync();

        public void EditJob(Job job) => Update(job);
        public void DeleteJob(Job job) => Delete(job);

        public async Task<List<Job>> GetAllJobsAsync(int jobId) => 
            await FindByCondition(c => c.JobId.Equals(jobId)).ToListAsync();
    }
}
