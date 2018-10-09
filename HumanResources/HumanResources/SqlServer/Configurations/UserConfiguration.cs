using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(user => user.Identification).IsRequired();
            builder.Property(user => user.Name).IsRequired();
            builder.Property(user => user.Lastname).IsRequired();
            builder.Property(user => user.Password).IsRequired();
        }
    }
}
