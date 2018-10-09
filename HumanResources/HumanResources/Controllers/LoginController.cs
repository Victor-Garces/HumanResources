using HumanResources.Controllers.ViewModels;
using HumanResources.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HumanResources.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public LoginController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult ValidateUser([FromBody] UserModel user)
        {
            bool isAdmin = _humanResourcesContext.Users
                .Include(user1 => user1.UsersRol)
                .ThenInclude(rol => rol.Rol)
                .Any(x => x.Email == user.Email 
                    && x.Password == user.Password 
                    && x.UsersRol.Any(rol => rol.Rol.Name == "Admin"));

            return Ok(isAdmin);
        }
    }
}