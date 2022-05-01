using GlobalAzure2022.Modules.Production.Domain.Entities;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace GlobalAzure2022.Modules.Production.Domain.CommandsHandler;

public sealed class BrewBeerCommandHandler : CommandHandlerAsync<BrewBeer>
{
    public BrewBeerCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
        : base(repository, loggerFactory)
    {
    }

    public override async Task HandleAsync(BrewBeer command, CancellationToken cancellationToken = new())
    {
        try
        {
            //TODO: Implement EventStore using Muflone.AggregateBase

            var beer = Beer.BrewBeer(command.BeerId, command.BeerType, command.BeerQuantity);

            await Repository.SaveAsync(beer, Guid.NewGuid());
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}