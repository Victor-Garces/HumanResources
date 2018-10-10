using System;
using System.Collections.Generic;
using HumanResources.SqlServer.Models;

namespace HumanResources.Controllers.ViewModels
{
    public sealed class CandidateModel
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }

        public Position Position { get; set; }
        public Guid PositionId { get; set; }

        public string Department { get; set; }
        public double AspiratedSalary { get; set; }

        public ISet<WorkExperience> WorkExperiences { get; set; }

        public string RecommendBy { get; set; }

        public ISet<Competition> Competitions { get; set; }
        public ISet<Training> Trainings { get; set; }
    }
}
