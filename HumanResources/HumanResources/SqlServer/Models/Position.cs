using HumanResources.Enums;
using System;

namespace HumanResources.SqlServer.Models
{
    public sealed class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PositionRiskLevel RiskLevel { get; set; }
        public double MinimumSalary { get; set; }
        public double MaximumSalary { get; set; }
        public PositionStatus Status { get; set; }
    }
}
