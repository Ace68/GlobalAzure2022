using GlobalAzure2022.Modules.Production.Factories;
using GlobalAzure2022.Modules.Pubs.Abstracts;
using GlobalAzure2022.Modules.Pubs.Concretes;
using GlobalAzure2022.Modules.Pubs.Handlers;
using GlobalAzure2022.Modules.Pubs.Messages.Events;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Azure.Factories;
using Muflone.Factories;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Modules.Pubs;

public static class PubsHelper
{
    public static IServiceCollection AddPubs(this IServiceCollection services)
    {
        services.AddScoped<IPubsService, PubsService>();

        services.AddScoped<IDomainEventHandlerAsync<BeerBrewed>, BeerBrewedEventHandler>();

        services.AddScoped<IDomainEventHandlerFactoryAsync, DomainEventHandlerFactory>();
        services.AddScoped<IDomainEventProcessorFactoryAsync, DomainEventProcessorFactoryAsync>();

        return services;
    }
}