using GlobalAzure2022.Production.Shared.Abstracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Azure.Factories;
using Muflone.Messages.Events;

namespace GlobalAzure2022.Production.Shared.Services;

public sealed class Publish : IPublish
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public Publish(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
    {
        _serviceProvider = serviceProvider;
        _logger = loggerFactory.CreateLogger(GetType());
    }

    public async Task PublishAsync<T>(T @event) where T : IDomainEvent
    {
        var domainEventProcessor = _serviceProvider.GetService<IDomainEventProcessorAsync<T>>();
        if (domainEventProcessor == null)
        {
            _logger.LogError($"[Publish.PublishAsync] - No DomainEvent consumer for {@event}");
            throw new Exception($"[Publish.PublishAsync] - No DomainEvent consumer for {@event}");
        }
        await domainEventProcessor.PublishAsync(@event);
    }
}