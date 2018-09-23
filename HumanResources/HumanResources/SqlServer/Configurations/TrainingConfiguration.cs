using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(training => training.Id);
            builder.Property(training => training.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(training => training.Description).IsRequired();
            builder.Property(training => training.Institution).IsRequired();
        }
    }
}
