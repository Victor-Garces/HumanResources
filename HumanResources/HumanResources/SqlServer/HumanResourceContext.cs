using HumanResources.SqlServer.Configurations;
using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.SqlServer
{
    public class HumanResourceContext : DbContext
    {
        public HumanResourceContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
        }
    }
}
