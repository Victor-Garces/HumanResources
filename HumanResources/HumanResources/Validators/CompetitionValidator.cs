using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class CompetitionValidator : AbstractValidator<Competition>
    {
        public CompetitionValidator()
        {
            RuleFor(competition => competition.Description).NotEmpty();
            RuleFor(competition => competition.Status).NotEmpty();
        }
    }
}
