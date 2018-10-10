using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResources.Controllers.ViewModels;
using HumanResources.SqlServer;
using HumanResources.SqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        readonly HumanResourceContext _humanResourcesContext;

        public EmployeeController(HumanResourceContext humanResourcesContext)
            => _humanResourcesContext = humanResourcesContext;

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeModel employeeModel)
        {
            var employee = new Employee
            {
                PositionId = employeeModel.Candidate.PositionId,
                AdmissionDate = DateTime.Now,
                Department = employeeModel.Candidate.Department,
                IsActive = true,
                MonthlySalary = employeeModel.MothlySalary,
                User = new User
                {
                    Identification = employeeModel.Candidate.Identification,
                    Password = employeeModel.Candidate.Name,
                    Email = employeeModel.Email,
                    Name = employeeModel.Candidate.Name,
                    Lastname = "",
                    UsersRol = new HashSet<UsersRol>
                    {
                        new UsersRol
                        {
                            RolId = Guid.Parse("B838A516-8822-41A8-BEE3-F91EB3FEA2D0")
                        }
                    }
                }
            };

            _humanResourcesContext.Employees.Add(employee);
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
        public IActionResult GetEmployees()
        {
            ISet<Employee> employees = _humanResourcesContext.Employees
                .ToHashSet();

            if (employees.Count == 0)
            {
                return BadRequest("Employees not found");
            }

            return Ok(employees);
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