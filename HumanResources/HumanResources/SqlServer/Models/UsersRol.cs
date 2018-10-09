using System;

namespace HumanResources.SqlServer.Models
{
    public sealed class UsersRol
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Rol Rol { get; set; }
        public Guid RolId { get; set; }
    }
}
