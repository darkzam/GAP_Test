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

    }
}
