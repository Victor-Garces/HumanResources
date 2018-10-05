using System;

namespace HumanResources.SqlServer.Models
{
    public class CandidateCompetition
    {
        public Guid Id { get; set; }

        public Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }

        public Competition Competition { get; set; }
        public Guid CompetitionId { get; set; }
    }
}
