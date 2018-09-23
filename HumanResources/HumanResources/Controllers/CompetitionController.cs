using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/competition")]
    public class CompetitionController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public CompetitionController(HumanResourceContext humanResourcesContext) 
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateCompetition([FromBody] Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid competition");
            }

            _humanResourcesContext.Competitions.Add(competition);
            _humanResourcesContext.SaveChanges();

            return Ok("Competition saved successfully");
        }

        [HttpGet("{competitionId}")]
        public IActionResult GetCompetition(Guid competitionId)
        {
            if (competitionId == Guid.Empty)
            {
                return BadRequest("Invalid competition identification");
            }

            Competition competition = _humanResourcesContext.Competitions.Find(competitionId);

            if (competition == null)
            {
                return BadRequest("Competition not found");
            }

            return Ok(competition);
        }

        [HttpGet]
        public IActionResult GetAllCompetitions()
        {
            ISet<Competition> competitions = _humanResourcesContext.Competitions.ToHashSet();

            if (competitions.Count == 0)
            {
                return BadRequest("Competitions not found");
            }

            return Ok(competitions);
        }

        [HttpPut("{competitionId}")]
        public IActionResult UpdateCompetition(Guid competitionId, [FromBody] Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid competition");
            }

            competition.Id = competitionId;

            _humanResourcesContext.Competitions.Update(competition);
            _humanResourcesContext.SaveChanges();

            return Ok(competition);
        }

        [HttpDelete("{competitionId}")]
        public IActionResult DeleteCompetition(Guid competitionId)
        {
            if (competitionId == Guid.Empty)
            {
                return BadRequest("Invalid competition identification");
            }

            Competition competition = _humanResourcesContext.Competitions.Find(competitionId);

            if (competition == null)
            {
                return BadRequest("Competition not found");
            }

            _humanResourcesContext.Competitions.Remove(competition);
            _humanResourcesContext.SaveChanges();

            return Ok("Competition removed successfully");
        }
    }
}