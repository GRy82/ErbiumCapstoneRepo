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

        public async Task<List<Job>> GetAllJobsAsync(int userId, Type type)
        {
            List<Job> jobs = new List<Job> { };
            if (type.Equals(new Customer().GetType()))
            {
                jobs = await FindByCondition(c => c.CustomerId.Equals(userId)).ToListAsync();
            }
            else
            {
                jobs = await FindByCondition(c => c.ContractorId.Equals(userId)).ToListAsync();
            }
            return jobs;
        }
        //public List<Job> ListOfAllJobs() => FindAll(Job).ToList();

        public async Task<List<Job>> GetAllCurrentJobsAsync(int userId, Type type)
        {
            List<Job> jobs = new List<Job> { };
            if (type.Equals(new Customer().GetType()))
            {
                jobs = await FindByCondition(c => c.CustomerId.Equals(userId) && c.JobState == "current").ToListAsync();
            }
            else
            {
                jobs = await FindByCondition(c => c.ContractorId.Equals(userId) && c.JobState == "current").ToListAsync();
            }

            return jobs;
        }

        public async Task<List<Job>> GetAllPostedJobsAsync(int userId, Type type)
        {
            List<Job> jobs = new List<Job> { };
            if (type.Equals(new Customer().GetType()))
            {
                jobs = await FindByCondition(c => c.CustomerId.Equals(userId) && c.JobState == "posted").ToListAsync();
            }
            else
            {
                jobs = await FindByCondition(c => c.JobState == "posted").ToListAsync();
            }

            return jobs;
        }

        public async Task<List<Job>> GetAllPastJobsAsync(int userId, Type type)
        {
            List<Job> jobs = new List<Job> { };
            if (type.Equals(new Customer().GetType()))
            {
                jobs = await FindByCondition(c => c.CustomerId.Equals(userId) && c.JobState == "past").ToListAsync();
            }
            else
            {
                jobs = await FindByCondition(c => c.ContractorId.Equals(userId) && c.JobState == "past").ToListAsync();
            }

            return jobs;
        }

    }
}
