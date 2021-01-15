﻿using ErbiumCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErbiumCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
             );
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<ContractorSkill> ContractorSkills {get; set;}
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contractor>()
                .HasData(
                new Contractor
                {
                    ContractorId = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    StreetAddress = "550 N Harbor Dr",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53202",
                    SkillType = "Plumber"

                },
                new Contractor
                {
                    ContractorId = 2,
                    FirstName = "Inigo",
                    LastName = "Montoya",
                    StreetAddress = "239 E Chicago St #103",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53202",
                    SkillType = "Electrical"
                },
                new Contractor
                {
                    ContractorId = 3,
                    FirstName = "Kirk",
                    LastName = "Lazarus",
                    StreetAddress = "4022 N Oakland Ave,",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53211",
                    SkillType = "Electrical"
                });

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Mc",
                    LastName = "Lovin",
                    StreetAddress = "346 N Broadway",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53202",

                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Saul",
                    LastName = "Silver",
                    StreetAddress = "728 E Brady St",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53202",

                }, 
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Wade",
                    LastName = "Wilson",
                    StreetAddress = "833 N Jefferson St,",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = "53202",

                });

            modelBuilder.Entity<Skill>()
                .HasData(
                new Skill
                {
                    SkillId = 1,
                    SkillType = "Plumber"
                },
                new Skill
                {
                    SkillId = 2,
                    SkillyType = "Electrical"
                });

            modelBuilder.Entity<ContractorSkill>()
                .HasData(
                new ContractorSkill
                {
                    ContractorSkillId = 1,
                    SkillId = 1,
                    contractorId = 1,
                },
                new ContractorSkill
                {
                    ContractorSkillId = 2,
                    SkillId = 2,
                    contractorId = 2,
                },
                new ContractorSkill
                {
                    ContractorSkillId = 3,
                    SkillId = 2,
                    ContractorId = 3,
                }
                );
        }
    }
}
