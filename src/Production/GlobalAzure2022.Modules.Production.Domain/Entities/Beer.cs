using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Production.Messages.Events;
using Muflone.Core;

namespace GlobalAzure2022.Modules.Production.Domain.Entities;

public class Beer : AggregateRoot
{
    private BeerType _beerType;
    private BeerQuantity _beerQuantity;

    protected Beer()
    {}

    internal static Beer BrewBeer(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity)
    {
        return new Beer(beerId, beerType, beerQuantity);
    }

    private Beer(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity)
    {
        RaiseEvent(new BeerBrewed(beerId, beerType, beerQuantity));
    }

    private void Apply(BeerBrewed @event)
    {
        Id = @event.BeerId;
        _beerType = @event.BeerType;
        _beerQuantity = @event.BeerQuantity;
    }
}