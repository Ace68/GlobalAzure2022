using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using GlobalAzure2022.Production.ReadModel.Abstracts;
using GlobalAzure2022.Production.ReadModel.Dtos;
using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.Logging;
using Muflone;

namespace GlobalAzure2022.Modules.Production.Concretes;

public class ProductionService : ProductionBaseService, IProductionService
{
    private readonly IServiceBus _serviceBus;

    public ProductionService(IPersister persister, ILoggerFactory loggerFactory, IServiceBus serviceBus)
        : base(persister, loggerFactory)
    {
        _serviceBus = serviceBus;
    }

    public Task<ProductionGreetings> SayHelloAsync(GreetingsRequest request)
    {
        return Task.FromResult(new ProductionGreetings
        {
            Message = $"Hello {request.Name} from Production"
        });
    }

    public async Task PrepareBeerAsync(BeersJson beerToBrew)
    {
        try
        {
            var brewBeer = new BrewBeer(new BeerId(Guid.NewGuid()), new BeerType(beerToBrew.BeerType),
                new BeerQuantity(beerToBrew.Quantity));
            await _serviceBus.SendAsync(brewBeer);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task BrewBeerAsync(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity)
    {
        try
        {
            var beer = await Persister.GetByIdAsync<Beers>(beerId.ToString());
            if (beer != null && !string.IsNullOrWhiteSpace(beer.Id))
                return;

            beer = Beers.CreateBeers(beerId, beerType, beerQuantity);
            await Persister.InsertAsync(beer);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task<IEnumerable<BeersJson>> GetBeersAsync()
    {
        try
        {
            var beers = await Persister.FindAsync<Beers>();
            var beersArray = beers as Beers[] ?? beers.ToArray();

            return beersArray.Any()
                ? beersArray.Select(b => b.ToJson())
                : Enumerable.Empty<BeersJson>();
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}