using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(competition => competition.Name).NotEmpty();
            RuleFor(competition => competition.MaximumSalary).NotEmpty();
            RuleFor(competition => competition.MinimumSalary).NotEmpty();
            RuleFor(competition => competition.RiskLevel).NotEmpty();
            RuleFor(competition => competition.Status).NotEmpty();
        }
    }
}
