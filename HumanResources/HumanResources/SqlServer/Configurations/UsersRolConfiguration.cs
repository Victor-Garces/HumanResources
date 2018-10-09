using HumanResources.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResources.SqlServer.Configurations
{
    public class UsersRolConfiguration : IEntityTypeConfiguration<UsersRol>
    {
        public void Configure(EntityTypeBuilder<UsersRol> builder) 
            => builder.HasKey(rol => new { rol.UserId, rol.RolId });
    }
}
