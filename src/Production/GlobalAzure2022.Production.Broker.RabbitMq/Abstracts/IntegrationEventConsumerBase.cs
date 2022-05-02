using MassTransit;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Production.Broker.RabbitMq.Abstracts
{
    public abstract class IntegrationEventConsumerBase<TEvent> : IConsumer<TEvent> where TEvent : IntegrationEvent
    {
        protected abstract IIntegrationEventHandlerAsync<TEvent> HandlerAsync { get; }
        public abstract Task Consume(ConsumeContext<TEvent> context);
    }
}