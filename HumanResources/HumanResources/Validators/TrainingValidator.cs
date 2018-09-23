using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class TrainingValidator : AbstractValidator<Training>
    {
        public TrainingValidator()
        {
            RuleFor(competition => competition.Description).NotEmpty();
            RuleFor(competition => competition.Institution).NotEmpty();
            RuleFor(competition => competition.EndDateTime).NotEmpty();
            RuleFor(competition => competition.StartDateTime).NotEmpty();
            RuleFor(competition => competition.Level).NotEmpty();
        }
    }
}
