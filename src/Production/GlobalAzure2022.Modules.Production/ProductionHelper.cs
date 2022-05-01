using FluentValidation.AspNetCore;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Concretes;
using GlobalAzure2022.Modules.Production.Domain.CommandsHandler;
using GlobalAzure2022.Modules.Production.Domain.Repository;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Messages.Commands;
using Muflone.Persistence;

namespace GlobalAzure2022.Modules.Production;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();

        services.AddSingleton<IRepository, InMemoryRepository>();
        services.AddScoped<ICommandHandlerAsync<BrewBeer>, BrewBeerCommandHandler>();

        services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ProductionService>());

        return services;
    }
}