using System;
using System.Collections.Generic;

namespace HumanResources.SqlServer.Models
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }

        public ISet<UsersRol> UsersRol { get; set; }
    }
}
