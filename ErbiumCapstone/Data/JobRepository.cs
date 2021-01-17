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

        public Job Update(int jobId) =>
            FindByCondition(c => c.JobId.Equals(jobId)).SingleOrDefault();
        public void Delete(int jobId) =>
            FindByCondition(c => c.JobId.Equals(jobId)).SingleOrDefault();

    }
}
