using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Production.Broker.RabbitMq.Abstracts
{
    public abstract class MassTransitDomainEventConsumer<T> : DomainEventConsumerBase<T> where T : DomainEvent
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly ILogger Logger;

        protected MassTransitDomainEventConsumer(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            ServiceProvider = serviceProvider;
            Logger = loggerFactory.CreateLogger(GetType());
        }
    }
}