using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillType { get; set; }
    }
}
