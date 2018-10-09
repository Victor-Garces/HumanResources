using System;
using System.Collections.Generic;

namespace HumanResources.SqlServer.Models
{
    public sealed class Candidate
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }

        public Position Position { get; set; }
        public Guid PositionId { get; set; }

        public string Department { get; set; }
        public double AspiratedSalary { get; set; }

        public WorkExperience WorkExperience { get; set; }
        public Guid WorkExperienceId { get; set; }

        public string RecommendBy { get; set; }

        public ISet<CandidateCompetition> CandidateCompetitions { get; set; }
        public ISet<CandidateTraining> CandidateTrainings { get; set; }
    }
}
