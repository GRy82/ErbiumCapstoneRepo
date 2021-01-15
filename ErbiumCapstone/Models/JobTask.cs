using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class JobTask
    {
        [Key]
        public int TaskId { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        public string Name { get; set; }
        public string  Description { get; set; }
        public bool IsCompleted { get; set; }
        //This will change based on data type info found
        public string CompletionImage { get; set; }

    }
}
