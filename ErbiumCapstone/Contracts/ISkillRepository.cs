using ErbiumCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface ISkillRepository : IRepositoryBase<Skill>
    {
        public Skill GetSkill(Skill skillId);
        public List<Skill> GetAllSkills(Skill skillId);
    }
}
