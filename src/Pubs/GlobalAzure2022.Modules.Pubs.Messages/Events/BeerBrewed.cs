using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Pubs.Extensions.CustomTypes;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Modules.Pubs.Messages.Events;

public sealed class BeerBrewed : DomainEvent
{
    public readonly BeerId BeerId;
    public readonly BeerType BeerType;
    public readonly BeerQuantity BeerQuantity;

    public BeerBrewed(BeerId aggregateId, BeerType beerType, BeerQuantity beerQuantity)
        : base(aggregateId)
    {
        BeerId = aggregateId;
        BeerType = beerType;
        BeerQuantity = beerQuantity;
    }
}