using System;
using System.Collections.Generic;

namespace HumanResources.SqlServer.Models
{
    public sealed class Rol
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ISet<UsersRol> UsersRol { get; set; }
    }
}
