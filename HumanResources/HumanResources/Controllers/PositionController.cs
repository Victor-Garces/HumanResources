using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/position")]
    public class PositionController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public PositionController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreatePosition([FromBody] Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid position");
            }

            _humanResourcesContext.Positions.Add(position);
            _humanResourcesContext.SaveChanges();

            return Ok("Position saved successfully");
        }

        [HttpGet("{positionId}")]
        public IActionResult GetPosition(Guid positionId)
        {
            if (positionId == Guid.Empty)
            {
                return BadRequest("Invalid position identification");
            }

            Position position = _humanResourcesContext.Positions.Find(positionId);

            if (position == null)
            {
                return BadRequest("Position not found");
            }

            return Ok(position);
        }

        [HttpGet]
        public IActionResult GetAllPositions()
        {
            ISet<Position> positions = _humanResourcesContext.Positions.ToHashSet();

            if (positions.Count == 0)
            {
                return BadRequest("Positions not found");
            }

            return Ok(positions);
        }

        [HttpPut("{positionId}")]
        public IActionResult UpdatePosition(Guid positionId, [FromBody] Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid position");
            }

            position.Id = positionId;

            _humanResourcesContext.Positions.Update(position);
            _humanResourcesContext.SaveChanges();

            return Ok(position);
        }

        [HttpDelete("{positionId}")]
        public IActionResult DeletePosition(Guid positionId)
        {
            if (positionId == Guid.Empty)
            {
                return BadRequest("Invalid position identification");
            }

            Position position = _humanResourcesContext.Positions.Find(positionId);

            if (position == null)
            {
                return BadRequest("Position not found");
            }

            _humanResourcesContext.Positions.Remove(position);
            _humanResourcesContext.SaveChanges();

            return Ok("Position removed successfully");
        }
    }
}