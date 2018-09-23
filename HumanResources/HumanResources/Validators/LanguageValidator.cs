using FluentValidation;
using HumanResources.SqlServer.Models;

namespace HumanResources.Validators
{
    public sealed class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(competition => competition.Name).NotEmpty();
            RuleFor(competition => competition.Status).NotEmpty();
        }
    }
}
