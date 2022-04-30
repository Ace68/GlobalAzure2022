using FluentValidation;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;

namespace GlobalAzure2022.Modules.Production.Validators;

public class GreetingsRequestValidator : AbstractValidator<GreetingsRequest>
{
    public GreetingsRequestValidator()
    {
        RuleFor(v => v.Name).NotEmpty();
    }
}