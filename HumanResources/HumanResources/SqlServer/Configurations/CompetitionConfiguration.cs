using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasKey(competition => competition.Id);
            builder.Property(competition => competition.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(competition => competition.Description).IsRequired();
        }
    }
}
