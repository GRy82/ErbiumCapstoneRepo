using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.ViewModels
{
    public class HomeViewModel
    {
        public Customer Customer { get; set; }
        public Contractor Contractor { get; set; }

        public Job ClickedJob { get; set; }
        public List<Job> CurrentJobs { get; set; }
        public List<Job> PostedJobs { get; set; }
        public List<Job> PastJobs { get; set; }
        public List<JobTask> JobTasks { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Image> JobImages { get; set; }
        public List<Image> JobTaskImages { get; set; }
    }
}
