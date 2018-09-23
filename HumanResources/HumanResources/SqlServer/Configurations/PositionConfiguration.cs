using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(position => position.Id);
            builder.Property(position => position.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(position => position.Name).IsRequired();
        }
    }
}
