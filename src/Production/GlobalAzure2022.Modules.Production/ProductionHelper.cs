using FluentValidation.AspNetCore;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Concretes;
using GlobalAzure2022.Modules.Production.Domain.CommandsHandler;
using GlobalAzure2022.Modules.Production.Domain.Repository;
using GlobalAzure2022.Modules.Production.Handlers;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using GlobalAzure2022.Modules.Production.Messages.Events;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Azure.Factories;
using Muflone.Factories;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace GlobalAzure2022.Modules.Production;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services, string servicebusConnectionString)
    {
        services.AddScoped<IProductionService, ProductionService>();

        services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ProductionService>());

        services.AddSingleton<IRepository, InMemoryRepository>();
        services.AddScoped<ICommandHandlerAsync<BrewBeer>, BrewBeerCommandHandler>();
        services.AddScoped<IDomainEventHandlerAsync<BeerBrewed>, BeerBrewedEventHandler>();

        services.AddScoped(provider =>
        {
            var domainEventHandlerFactory = provider.GetService<IDomainEventHandlerFactoryAsync>();

            var brokerOptions = new BrokerOptions
            {   
                ConnectionString = servicebusConnectionString,
                TopicName = nameof(BeerBrewed).ToLower(),
                SubscriptionName = "production-subscription"
            };

            var domainEventConsumerFactory =
                new ServiceBusEventProcessorFactory<BeerBrewed>(brokerOptions, domainEventHandlerFactory);
            return domainEventConsumerFactory.DomainEventProcessorAsync;
        });

        return services;
    }
}