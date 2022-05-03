using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Pubs.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Pubs.Extensions.JsonResponses;

namespace GlobalAzure2022.Modules.Pubs.Abstracts;

public interface IPubsService
{
    Task<string> SayHelloAsync();
    Task BrewBeerAsync(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity);

    Task<IEnumerable<BeersJson>> GetBeersAsync();
}