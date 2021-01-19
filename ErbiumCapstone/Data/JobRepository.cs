using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
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

        public Job GetJob(int jobId) =>
            FindByCondition(c => c.JobId.Equals(jobId)).SingleOrDefault();

        public void EditJob(Job job) => Update(job);
        public void DeleteJob(Job job) => Delete(job);

        public List<Job> GetAllJobs(int jobId) => 
            FindByCondition(c => c.JobId.Equals(jobId)).ToList();

        
    }
}
