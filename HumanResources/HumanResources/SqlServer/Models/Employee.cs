using System;

namespace HumanResources.SqlServer.Models
{
    public sealed class Employee
    {
        public Guid Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Department { get; set; }

        public Position Position { get; set; }
        public Guid PositionId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public double MonthlySalary { get; set; }
        public bool IsActive { get; set; }
    }
}
