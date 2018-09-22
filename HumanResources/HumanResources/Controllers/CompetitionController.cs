using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    [Route("api/competition")]
    public class CompetitionController : Controller
    {
        [HttpPost]
        public IActionResult CreateCompetition([FromBody] string description)
        {
            if (description == string.Empty)
            {
                return BadRequest();
            }

            var competition = new Competition
            {
                Description = description
            };

            return Ok();
        }
    }
}