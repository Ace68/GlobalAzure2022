using GlobalAzure2022.Production.Shared.Configuration;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone;

namespace GlobalAzure2022.Production.Broker.RabbitMq;

public static class RabbitMqHelper
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, ServiceBusOptions serviceBusOptions,
        EventStoreParameters eventStoreParameters)
    {
        services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(serviceBusOptions.BrokerUrl, host =>
            {
                host.Username(serviceBusOptions.Login);
                host.Password(serviceBusOptions.Password);
            });

            var loggerFactory = provider.GetService<ILoggerFactory>() ?? new NullLoggerFactory();
            var localProvider = services.BuildServiceProvider();

            cfg.ReceiveEndpoint(serviceBusOptions.QueueName, endpoint =>
            {
                endpoint.Bind(serviceBusOptions.ExchangeName);
                endpoint.PrefetchCount = 16;
                endpoint.UseMessageRetry(x => x.Interval(2, 100));

                #region CommandsConsumers
                //endpoint.Consumer(() => new SubmitProductionOrderConsumer(localProvider, loggerFactory));
                #endregion

                #region EventsConsumers
                //endpoint.Consumer(() => new ItemFromMagoSubmittedConsumer(localProvider, loggerFactory));

                //endpoint.Consumer(() => new EventSubmittedConsumer(localProvider, loggerFactory));
                #endregion

                #region SagaConsumer
                #endregion
            });
        }));

        services.AddSingleton<IServiceBus, RmqServiceBus>();
        services.AddSingleton<IHostedService, RmqServiceBus>();

        return services;
    }
}