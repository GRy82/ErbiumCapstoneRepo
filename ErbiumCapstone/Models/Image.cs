using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
