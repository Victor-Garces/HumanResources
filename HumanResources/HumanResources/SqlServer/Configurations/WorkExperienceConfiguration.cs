using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.HasKey(experience => experience.Id);
            builder.Property(experience => experience.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(experience => experience.Company).IsRequired();
            builder.Property(experience => experience.DateFrom).IsRequired();
            builder.Property(experience => experience.DateTo).IsRequired();
            builder.Property(experience => experience.OccupiedPosition).IsRequired();
            builder.Property(experience => experience.Salary).IsRequired();
        }
    }
}
