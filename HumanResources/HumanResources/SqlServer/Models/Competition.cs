using HumanResources.Enums;
using System;
using System.Collections.Generic;

namespace HumanResources.SqlServer.Models
{
    public sealed class Competition
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public CompetitionStatus Status { get; set; }

        public ISet<CandidateCompetition> CandidateCompetitions { get; set; }
    }
}
