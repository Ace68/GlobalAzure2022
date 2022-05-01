using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Modules.Production.Abstracts;

public interface IProductionService
{
    Task<ProductionGreetings> SayHelloAsync(GreetingsRequest request);

    Task PrepareBeerAsync(BeersJson beerToBrew);
    Task BrewBeerAsync(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity);

    Task<IEnumerable<BeersJson>> GetBeersAsync();
}