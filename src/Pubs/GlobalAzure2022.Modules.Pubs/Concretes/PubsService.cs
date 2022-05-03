using GlobalAzure2022.Modules.Production.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Pubs.Abstracts;
using GlobalAzure2022.Modules.Pubs.Extensions.CustomTypes;
using GlobalAzure2022.Modules.Pubs.Extensions.JsonResponses;
using GlobalAzure2022.Pubs.ReadModel.Abstracts;
using GlobalAzure2022.Pubs.ReadModel.Dtos;
using GlobalAzure2022.Pubs.Shared.Services;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Modules.Pubs.Concretes;

public class PubsService : PubsBaseService, IPubsService
{
    public PubsService(IPersister persister, ILoggerFactory loggerFactory) : base(persister, loggerFactory)
    {
    }

    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Pubs");
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