using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;
using GlobalAzure2022.Production.ReadModel.Abstracts;
using GlobalAzure2022.Production.ReadModel.Dtos;
using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Modules.Production.Concretes;

public class ProductionService : ProductionBaseService, IProductionService
{
    public ProductionService(IPersister persister, ILoggerFactory loggerFactory)
        : base(persister, loggerFactory)
    {
    }

    public Task<ProductionGreetings> SayHelloAsync(GreetingsRequest request)
    {
        return Task.FromResult(new ProductionGreetings
        {
            Message = $"Hello {request.Name} from Production"
        });
    }

    public async Task BrewBeerAsync(BeerId beerId, BeerType beerType, BeerQuantity beerQuantity)
    {
        try
        {
            throw new NotImplementedException();
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