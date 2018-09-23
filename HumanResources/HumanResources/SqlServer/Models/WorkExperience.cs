using System;

namespace HumanResources.SqlServer.Models
{
    public sealed class WorkExperience
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string OccupiedPosition { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double Salary { get; set; }
    }
}
