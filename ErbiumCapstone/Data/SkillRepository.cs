using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using ErbiumCapstone.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Data
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private object _repo;

        public SkillRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public Skill GetSkill(Skill skillId) =>
            FindByCondition(c => c.SkillId.Equals(skillId)).FirstOrDefault();

        public List<Skill> GetAllSkills(Skill skillId) =>
            FindByCondition(c => c.SkillId.Equals(skillId)).ToList();
    }
}
