using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Display(Name = "Job Name")]
        public string JobName { get; set; }

        [Display(Name = "Job Type")]
        public string JobType { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; } //needs to remain nullible type so that it does no default to value of 0.
        public Customer Customer { get; set; }

        [ForeignKey("Contractor")]
        public int? ContractorId { get; set; }
        public Contractor Contractor { get; set; }

        public string Description { get; set; }

        [Display(Name = "Cost")]
        public double ProposedCost { get; set; }
        public double AgreedCost { get; set; }
        public DateTime? DeadLine { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? JobStart { get; set; }

        [Display(Name = "Completion Date")]
        public DateTime? JobCompletion { get; set; }
        public TimeSpan? JobDuration { get; set; }
        public bool isJobCompletionApproved { get; set; }
        public string JobState { get; set; }

        [Display(Name = "Provide Updates")]
        public bool ProvideUpdates { get; set; }

        [Display(Name = "Provide Progress Pictures")]
        public bool ProvidePix { get; set; }

        [Display(Name = "Updates Required")]
        public int NumberOfUpdates { get; set; }
        public bool CustomerAcceptedJob { get; set; }
        public bool ContractorAcceptedJob { get; set; }

    }
}
