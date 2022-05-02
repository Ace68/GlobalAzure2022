using MassTransit;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Production.Broker.RabbitMq;

public sealed class RmqPublish : IPublish
{
    private readonly ILogger _logger;
    private readonly IBusControl _busControl;

    public RmqPublish(IBusControl busControl, ILoggerFactory loggerFactory)
    {
        _busControl = busControl;
        _logger = loggerFactory.CreateLogger(GetType());
    }

    public async Task PublishAsync<T>(T @event) where T : IDomainEvent
    {
        await _busControl.Publish(@event);
    }
}