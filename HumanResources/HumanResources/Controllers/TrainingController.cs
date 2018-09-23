using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/training")]
    public class TrainingController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public TrainingController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateTraining([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid training");
            }

            _humanResourcesContext.Trainings.Add(training);
            _humanResourcesContext.SaveChanges();

            return Ok("Training saved successfully");
        }

        [HttpGet("{trainingId}")]
        public IActionResult GetTraining(Guid trainingId)
        {
            if (trainingId == Guid.Empty)
            {
                return BadRequest("Invalid training identification");
            }

            Training training = _humanResourcesContext.Trainings.Find(trainingId);

            if (training == null)
            {
                return BadRequest("Training not found");
            }

            return Ok(training);
        }

        [HttpGet]
        public IActionResult GetAllTrainings()
        {
            ISet<Training> trainings = _humanResourcesContext.Trainings.ToHashSet();

            if (trainings.Count == 0)
            {
                return BadRequest("Trainings not found");
            }

            return Ok(trainings);
        }

        [HttpPut("{trainingId}")]
        public IActionResult UpdateTraining(Guid trainingId, [FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid training");
            }

            training.Id = trainingId;

            _humanResourcesContext.Trainings.Update(training);
            _humanResourcesContext.SaveChanges();

            return Ok(training);
        }

        [HttpDelete("{trainingId}")]
        public IActionResult DeleteTraining(Guid trainingId)
        {
            if (trainingId == Guid.Empty)
            {
                return BadRequest("Invalid training identification");
            }

            Training training = _humanResourcesContext.Trainings.Find(trainingId);

            if (training == null)
            {
                return BadRequest("Training not found");
            }

            _humanResourcesContext.Trainings.Remove(training);
            _humanResourcesContext.SaveChanges();

            return Ok("Training removed successfully");
        }
    }
}