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
    public class JobTaskRepository : RepositoryBase<JobTask>, IJobTaskRepository
    {
        private object _repo;
        public JobTaskRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public void CreateJobTask(JobTask jobTask) => Create(jobTask);

        public async Task<JobTask> GetJobTaskAsync(int jobTaskId) =>
            await FindByCondition(c => c.JobId.Equals(jobTaskId)).FirstOrDefaultAsync();

        public async Task<List<JobTask>> GetAllJobTasksAsync() =>
            await FindAll().ToListAsync();

        public async Task<List<JobTask>> GetAllCurrentJobTasksAsync(List<Job> currentJobs)
        {
            List<JobTask> currentJobTasks = new List<JobTask> { };
            foreach (Job job in currentJobs)
            {
                List<JobTask> tasks = await FindByCondition(c => c.JobId.Equals(job.JobId)).ToListAsync();
                foreach(JobTask task in tasks)
                {
                    currentJobTasks.Add(task);
                }
            }
            return currentJobTasks;
        }

        public void EditJobTask(JobTask jobTask) => Update(jobTask);
        public void DeleteJobTask(JobTask jobTask) => Delete(jobTask);
    }
}
