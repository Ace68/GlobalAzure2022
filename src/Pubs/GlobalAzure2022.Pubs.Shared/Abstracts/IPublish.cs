using Muflone.Messages.Events;

namespace GlobalAzure2022.Pubs.Shared.Abstracts;

public interface IPublish
{
    Task PublishAsync<T>(T @event) where T : IDomainEvent;
}