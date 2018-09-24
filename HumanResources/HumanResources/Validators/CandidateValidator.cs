using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(candidate => candidate.Department).NotEmpty();
            RuleFor(candidate => candidate.PositionId).NotEmpty();
            RuleFor(candidate => candidate.Identification).NotEmpty();
            RuleFor(candidate => candidate.Name).NotEmpty();
            RuleFor(candidate => candidate.WorkExperienceId).NotEmpty();
            RuleFor(candidate => candidate.AspiratedSalary).NotEmpty();
        }
    }
}
