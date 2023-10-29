using CleanBuilding.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = CleanBuilding.Domain.Object;

namespace CleanBuilding.Infrastructure.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<DataField> DataFields => Set<DataField>();
        public DbSet<Object> Objects => Set<Object>();
        public DbSet<Reading> Readings => Set<Reading>();

        // Used by Dapper
        public IDbConnection Connection => Database.GetDbConnection();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
           .Entity<Building>()
           .ToTable(nameof(Buildings));
            
            modelBuilder
           .Entity<DataField>()
           .ToTable(nameof(DataFields));

            modelBuilder
           .Entity<Object>()
           .ToTable(nameof(Objects));

            modelBuilder
           .Entity<Reading>()
           .ToTable(nameof(Readings));

            base.OnModelCreating(modelBuilder);
        }
    }
}
