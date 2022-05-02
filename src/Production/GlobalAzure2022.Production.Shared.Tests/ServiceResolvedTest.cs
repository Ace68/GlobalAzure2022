using System;
using FluentValidation.AspNetCore;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Concretes;
using GlobalAzure2022.Modules.Production.Domain.CommandsHandler;
using GlobalAzure2022.Modules.Production.Domain.Repository;
using GlobalAzure2022.Modules.Production.Factories;
using GlobalAzure2022.Modules.Production.Handlers;
using GlobalAzure2022.Modules.Production.Messages.Commands;
using GlobalAzure2022.Modules.Production.Messages.Events;
using GlobalAzure2022.Production.Mediator;
using GlobalAzure2022.Production.ReadModel.MongoDb;
using GlobalAzure2022.Production.Shared.Abstracts;
using GlobalAzure2022.Production.Shared.Configuration;
using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Muflone;
using Muflone.Azure.Factories;
using Muflone.Factories;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Xunit;

namespace GlobalAzure2022.Production.Shared.Tests
{
    public class ServiceResolvedTest
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceResolvedTest()
        {
            var services = new ServiceCollection();

            services.AddLogging();

            services.AddScoped<IServiceBus, InProcessServiceBus>();
            services.AddScoped<IPublish, Publish>();
            services.AddScoped<IRegisterHandler, RegisterHandlers>();

            services.AddMongoDb(new MongoDbParameters
            {
                ConnectionString = "mongodb://localhost",
                DatabaseName = "BrewUp-Production"
            });

            services.AddScoped<IProductionService, ProductionService>();

            services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ProductionService>());

            services.AddScoped<IRepository, InMemoryRepository>();
            services.AddScoped<ICommandHandlerAsync<BrewBeer>, BrewBeerCommandHandler>();
            services.AddScoped<IDomainEventHandlerAsync<BeerBrewed>, BeerBrewedEventHandler>();

            services.AddScoped<IDomainEventHandlerFactoryAsync, DomainEventHandlerFactory>();
            services.AddScoped<IDomainEventProcessorFactoryAsync, DomainEventProcessorFactoryAsync>();

            services.AddScoped(provider =>
            {
                var domainEventHandlerFactory = provider.GetService<IDomainEventHandlerFactoryAsync>();

                var brokerOptions = new BrokerOptions
                {
                    ConnectionString = "Endpoint=sb://brewup.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=B9e5eo3WvsO+furB5vjVtqCGkQR/WsNFmaGncQ780Ao=",
                    TopicName = nameof(BeerBrewed).ToLower(),
                    SubscriptionName = "production-subscription"
                };

                var domainEventConsumerFactory =
                    new ServiceBusEventProcessorFactory<BeerBrewed>(brokerOptions, domainEventHandlerFactory);
                return domainEventConsumerFactory.DomainEventProcessorAsync;
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void Can_Resolve_Factories()
        {
            var domainEventProcessor = _serviceProvider.GetService<IDomainEventProcessorAsync<BeerBrewed>>();
            Assert.NotNull(domainEventProcessor);
        }
    }
}