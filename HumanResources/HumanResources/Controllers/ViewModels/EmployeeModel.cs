using HumanResources.SqlServer.Models;

namespace HumanResources.Controllers.ViewModels
{
    public sealed class EmployeeModel
    {
        public Candidate Candidate { get; set; }
        public int MothlySalary { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
