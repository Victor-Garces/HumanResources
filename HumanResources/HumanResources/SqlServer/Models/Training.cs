﻿using HumanResources.Enums;
using System;
using System.Collections.Generic;

namespace HumanResources.SqlServer.Models
{
    public sealed class Training
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public TrainingLevel Level { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Institution { get; set; }

        public ISet<CandidateTraining> CandidateTrainings { get; set; }
    }
}
