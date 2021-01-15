using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> 9e4eecac766dc33465c1f757cff0a5e38461b9e2
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
<<<<<<< HEAD
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
=======
>>>>>>> 9e4eecac766dc33465c1f757cff0a5e38461b9e2
    }
}
