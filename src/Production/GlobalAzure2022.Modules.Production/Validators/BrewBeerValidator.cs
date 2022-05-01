using FluentValidation;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;

namespace GlobalAzure2022.Modules.Production.Validators;

public class BrewBeerValidator : AbstractValidator<BeersJson>
{
    public BrewBeerValidator()
    {
        RuleFor(v => v.BeerType).NotEmpty();
        RuleFor(v => v.Quantity).GreaterThan(0);
    }
}