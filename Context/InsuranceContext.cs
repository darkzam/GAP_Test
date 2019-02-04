using GAP.Insurance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Context
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options)
           : base(options)
        { }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<CoverageType> CoverageTypes { get; set; }

        public DbSet<RiskType> RiskTypes { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasKey(c => new { c.ClientId, c.PolicyId });
        }
    }
}
