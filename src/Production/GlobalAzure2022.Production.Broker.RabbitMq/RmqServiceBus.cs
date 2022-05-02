using GlobalAzure2022.Production.Shared.Services;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Muflone;
using Muflone.Messages;
using Muflone.Messages.Commands;

namespace GlobalAzure2022.Production.Broker.RabbitMq;

public sealed class RmqServiceBus : IServiceBus, IHostedService
{
    private readonly IBusControl _busControl;
    private readonly ILogger _logger;

    private readonly string _queueName = string.Empty;

    public RmqServiceBus(IBusControl busControl,
        ILoggerFactory loggerFactory,
        IOptions<ServiceBusOptions> options)
    {
        _busControl = busControl ?? throw new ArgumentNullException(nameof(busControl));
        _logger = loggerFactory.CreateLogger(GetType());

        _queueName = options.Value.BrokerUrl;
        if (!_queueName.EndsWith("/"))
            _queueName = $"{_queueName}/";

        _queueName = $"{_queueName}{options.Value.ExchangeName}";
    }

    public async Task SendAsync<T>(T command) where T : class, ICommand
    {
        try
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri(_queueName));
            await endpoint.Send(command);
        }
        catch (Exception ex)
        {
            _logger.LogError($"RMQ Queue: {_queueName}");
            _logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public Task RegisterHandlerAsync<T>(Action<T> handler) where T : IMessage
    {
        return Task.CompletedTask;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"RabbitMQ Bus Started at {DateTime.Now}");
        return _busControl.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"RabbitMQ Bus Stopped at {DateTime.Now}");
        return _busControl.StopAsync(cancellationToken);
    }
}