using System;

namespace HumanResources.SqlServer.Models
{
    public class CandidateTraining
    {
        public Guid Id { get; set; }

        public Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }

        public Training Training { get; set; }
        public Guid TrainingId { get; set; }
    }
}
