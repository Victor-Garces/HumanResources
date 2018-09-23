using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class WorkExperienceValidator : AbstractValidator<WorkExperience>
    {
        public WorkExperienceValidator()
        {
            RuleFor(experience => experience.Company).NotEmpty();
            RuleFor(candidate => candidate.DateFrom).NotEmpty();
            RuleFor(candidate => candidate.DateTo).NotEmpty();
            RuleFor(candidate => candidate.OccupiedPosition).NotEmpty();
            RuleFor(candidate => candidate.Salary).NotEmpty();
        }
    }
}
