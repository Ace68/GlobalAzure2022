using MassTransit;
using Muflone.Messages.Commands;

namespace GlobalAzure2022.Production.Broker.RabbitMq.Abstracts;

public abstract class CommandConsumerBase<TCommand> : IConsumer<TCommand> where TCommand : Command
{
    protected abstract ICommandHandlerAsync<TCommand> HandlerAsync { get; }
    public abstract Task Consume(ConsumeContext<TCommand> context);
}