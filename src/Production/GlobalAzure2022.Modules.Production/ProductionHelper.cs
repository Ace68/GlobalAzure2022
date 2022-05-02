using FluentValidation.AspNetCore;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Concretes;
using GlobalAzure2022.Modules.Production.Domain.CommandsHandler;
using GlobalAzure2022.Modules.Production.Factories;
using GlobalAzure2022.Modules.Production.Handlers;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using GlobalAzure2022.Modules.Production.Messages.Events;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Azure.Factories;
using Muflone.Factories;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Modules.Production;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();

        services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ProductionService>());

        services.AddScoped<ICommandHandlerAsync<BrewBeer>, BrewBeerCommandHandler>();
        services.AddScoped<IDomainEventHandlerAsync<BeerBrewed>, BeerBrewedEventHandler>();
        
        services.AddScoped<IDomainEventHandlerFactoryAsync, DomainEventHandlerFactory>();
        services.AddScoped<IDomainEventProcessorFactoryAsync, DomainEventProcessorFactoryAsync>();

        return services;
    }
}