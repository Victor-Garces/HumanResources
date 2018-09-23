using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/work-experience")]
    public class WorkExperienceController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public WorkExperienceController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateWorkExperience([FromBody] WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid work experience");
            }

            _humanResourcesContext.WorkExperiences.Add(workExperience);
            _humanResourcesContext.SaveChanges();

            return Ok("Work experience saved successfully");
        }

        [HttpGet("{workExperienceId}")]
        public IActionResult GetWorkExperience(Guid workExperienceId)
        {
            if (workExperienceId == Guid.Empty)
            {
                return BadRequest("Invalid work experience identification");
            }

            WorkExperience workExperience = _humanResourcesContext.WorkExperiences.Find(workExperienceId);

            if (workExperience == null)
            {
                return BadRequest("Work experience not found");
            }

            return Ok(workExperience);
        }

        [HttpGet]
        public IActionResult GetAllWorkExperiences()
        {
            ISet<WorkExperience> workExperiences = _humanResourcesContext.WorkExperiences.ToHashSet();

            if (workExperiences.Count == 0)
            {
                return BadRequest("Work experience not found");
            }

            return Ok(workExperiences);
        }

        [HttpPut("{workExperienceId}")]
        public IActionResult UpdateWorkExperience(Guid workExperienceId, [FromBody] WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid work experience");
            }

            workExperience.Id = workExperienceId;

            _humanResourcesContext.WorkExperiences.Update(workExperience);
            _humanResourcesContext.SaveChanges();

            return Ok(workExperience);
        }

        [HttpDelete("{workExperienceId}")]
        public IActionResult DeleteWorkExperience(Guid workExperienceId)
        {
            if (workExperienceId == Guid.Empty)
            {
                return BadRequest("Invalid work experience identification");
            }

            WorkExperience workExperience = _humanResourcesContext.WorkExperiences.Find(workExperienceId);

            if (workExperience == null)
            {
                return BadRequest("Work experience not found");
            }

            _humanResourcesContext.WorkExperiences.Remove(workExperience);
            _humanResourcesContext.SaveChanges();

            return Ok("Work experience removed successfully");
        }
    }
}