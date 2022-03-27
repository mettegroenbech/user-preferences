﻿using Microsoft.EntityFrameworkCore;
using PreferenceManagement.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreferenceManagement.API.Infrastructure.Database
{
    public class PreferenceContext : DbContext
    {
        public PreferenceContext(DbContextOptions<PreferenceContext> options)
            : base(options)
        {
        }

        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Preference>().HasData(
                new Preference
                {
                    Id = Guid.NewGuid(),
                    Key = "DARK_MODE",
                    Level = Level.Solution,
                    Solution = "ExampleSolution"
                },                
                new Preference
                {
                    Id = Guid.NewGuid(),
                    Key = "EMAIL_NOTIFICATIONS",
                    Level = Level.Solution,
                    Solution = "ExampleSolution"
                },
                new Preference
                {
                    Id = Guid.NewGuid(),
                    Key = "ANALYTICS_CONSENT",
                    Level = Level.Universal
                }
            );
        }
    }
}
