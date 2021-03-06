﻿using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context; 
        private IContractorRepository _contractor;
        private ICustomerRepository _customer;
        private IJobRepository _job;
        private IJobTaskRepository _jobTask;
        private IImageRepository _image;


        public IImageRepository Image
        {
            get
            {
                if (_image == null)
                {
                    _image = new ImageRepository(_context);
                }
                return _image;
            }
        }
        public IJobTaskRepository JobTask
        {
            get
            {
                if (_jobTask == null)
                {
                    _jobTask = new JobTaskRepository(_context);
                }
                return _jobTask;
            }
        }
        public IJobRepository Job
        {
            get
            {
                if (_job == null)
                {
                    _job = new JobRepository(_context);
                }
                return _job;
            }
        }
        public IContractorRepository Contractor
        {
            get
            {
                if (_contractor == null)
                {
                    _contractor = new ContractorRepository(_context);
                }
                return _contractor;
            }
        }
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_context);
                }
                return _customer;
            }
        }

        public ISkillRepository Skill => throw new NotImplementedException();

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
