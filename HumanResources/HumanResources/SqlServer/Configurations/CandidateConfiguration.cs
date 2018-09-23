using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(competition => competition.Id);
            builder.Property(competition => competition.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(competition => competition.Department).IsRequired();
            builder.Property(competition => competition.Identification).IsRequired();
            builder.Property(competition => competition.MainCompetences).IsRequired();
            builder.Property(competition => competition.MainTrainings).IsRequired();
            builder.Property(competition => competition.Name).IsRequired();
        }
    }
}
