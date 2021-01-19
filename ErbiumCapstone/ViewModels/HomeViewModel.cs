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
        public List<Job> Jobs { get; set; }
        public List<Skill> Skills { get; set; }
        public Job job { get; set; }
    }
}
