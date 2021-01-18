using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
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

        public JobTask GetJobTask(int jobTaskId) =>
            FindByCondition(c => c.JobId.Equals(jobTaskId)).SingleOrDefault();

        public void EditJobTask(JobTask jobTask) => Update(jobTask);
        public void DeleteJobTask(JobTask jobTask) => Delete(jobTask);
    }
}
