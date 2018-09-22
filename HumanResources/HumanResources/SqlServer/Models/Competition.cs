using HumanResources.Enums;
using System;

namespace HumanResources.SqlServer.Models
{
    public sealed class Competition
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CompetitionStatus Status { get; set; }
    }
}
