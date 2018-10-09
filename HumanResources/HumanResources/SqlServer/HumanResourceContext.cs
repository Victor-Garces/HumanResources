using HumanResources.SqlServer.Configurations;
using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.SqlServer
{
    public class HumanResourceContext : DbContext
    {
        public HumanResourceContext(DbContextOptions options) : base(options) { }

        internal DbSet<Competition> Competitions { get; set; }
        internal DbSet<Language> Languages { get; set; }
        internal DbSet<Training> Trainings { get; set; } 
        internal DbSet<Position> Positions { get; set; }
        internal DbSet<Candidate> Candidates { get; set; }
        internal DbSet<WorkExperience> WorkExperiences { get; set; }
        internal DbSet<Employee> Employees { get; set; }
        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new WorkExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
