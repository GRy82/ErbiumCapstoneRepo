using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

    }
}
