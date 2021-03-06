﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Contracts
{
    public interface IRepositoryWrapper
    {
        ISkillRepository Skill { get; }
        ICustomerRepository Customer { get; }
        IContractorRepository Contractor { get; }
        IJobRepository Job { get; }
        IJobTaskRepository JobTask { get; }
        IImageRepository Image { get; }
        Task SaveAsync();
    }
}
