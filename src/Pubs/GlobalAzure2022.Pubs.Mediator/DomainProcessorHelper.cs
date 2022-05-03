using GlobalAzure2022.Modules.Pubs.Messages.Events;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Azure.Factories;
using Muflone.Factories;

namespace GlobalAzure2022.Pubs.Mediator;

public static class DomainProcessorHelper
{
    public static IServiceCollection AddDomainProcessor(this IServiceCollection services, string servicebusConnectionString)
    {
        services.AddScoped(provider =>
        {
            var domainEventHandlerFactory = provider.GetService<IDomainEventHandlerFactoryAsync>();

            var brokerOptions = new BrokerOptions
            {
                ConnectionString = servicebusConnectionString,
                TopicName = nameof(BeerBrewed).ToLower(),
                SubscriptionName = "pubs-subscription"
            };

            var domainEventConsumerFactory =
                new ServiceBusEventProcessorFactory<BeerBrewed>(brokerOptions, domainEventHandlerFactory);
            return domainEventConsumerFactory.DomainEventProcessorAsync;
        });

        return services;
    }
}