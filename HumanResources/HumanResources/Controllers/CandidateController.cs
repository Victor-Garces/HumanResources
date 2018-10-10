﻿using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HumanResources.Controllers.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Controllers
{
    [Route("api/candidate")]
    public class CandidateController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public CandidateController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateCandidate([FromBody] CandidateModel candidateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid candidate");
            }

            var candidate = new Candidate
            {
                WorkExperiences = candidateModel.WorkExperiences ?? new HashSet<WorkExperience>(),
                PositionId = candidateModel.PositionId,
                AspiratedSalary = candidateModel.AspiratedSalary,
                Department = candidateModel.Department,
                Identification = candidateModel.Identification,
                Name = candidateModel.Name,
                RecommendBy = candidateModel.RecommendBy,
                CandidateCompetitions = candidateModel.Competitions.Select(value => new CandidateCompetition
                {
                    CompetitionId = value.Id
                }).ToHashSet() ?? new HashSet<CandidateCompetition>(),
                CandidateTrainings = candidateModel.Trainings.Select(value => new CandidateTraining
                {
                    TrainingId = value.Id
                }).ToHashSet() ?? new HashSet<CandidateTraining>()
            };

            _humanResourcesContext.Candidates.Add(candidate);
            _humanResourcesContext.SaveChanges();

            return Ok("Candidate saved successfully");
        }

        [HttpGet("{candidateId}")]
        public IActionResult GetCandidate(Guid candidateId)
        {
            if (candidateId == Guid.Empty)
            {
                return BadRequest("Invalid candidate identification");
            }

            Candidate candidate = _humanResourcesContext.Candidates
                .Include(c => c.Position)
                .FirstOrDefault(c => c.Id == candidateId);

            if (candidate == null)
            {
                return BadRequest("Candidate not found");
            }

            return Ok(candidate);
        }

        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            ISet<Candidate> candidates = _humanResourcesContext.Candidates
                .Include(c => c.Position)
                .ToHashSet();

            if (candidates.Count == 0)
            {
                return BadRequest("Candidates not found");
            }

            return Ok(candidates);
        }

        [HttpPut("{candidateId}")]
        public IActionResult UpdateCandidate(Guid candidateId, [FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid candidate");
            }

            candidate.Id = candidateId;

            _humanResourcesContext.Candidates.Update(candidate);
            _humanResourcesContext.SaveChanges();

            return Ok(candidate);
        }

        [HttpDelete("{candidateId}")]
        public IActionResult DeleteCandidate(Guid candidateId)
        {
            if (candidateId == Guid.Empty)
            {
                return BadRequest("Invalid candidate identification");
            }

            Candidate candidate = _humanResourcesContext.Candidates.Find(candidateId);

            if (candidate == null)
            {
                return BadRequest("Candidate not found");
            }

            _humanResourcesContext.Candidates.Remove(candidate);
            _humanResourcesContext.SaveChanges();

            return Ok("Candidate removed successfully");
        }
    }
}