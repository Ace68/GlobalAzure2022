using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using Muflone.Messages.Commands;

namespace GlobalAzure2022.Modules.Production.Messages.Commands;

public sealed class BrewBeer : Command
{
    public readonly BeerId BeerId;
    public readonly BeerType BeerType;
    public readonly BeerQuantity BeerQuantity;

    public BrewBeer(BeerId aggregateId, BeerType beerType, BeerQuantity beerQuantity)
        : base(aggregateId)
    {
        BeerId = aggregateId;
        BeerType = beerType;
        BeerQuantity = beerQuantity;
    }
}