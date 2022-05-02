using GlobalAzure2022.Modules.Production.Domain.Repository;
using GlobalAzure2022.Production.Shared.Abstracts;
using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Muflone.Persistence;

namespace GlobalAzure2022.Production.Mediator;

public static class MediatorHelper
{
    public static IServiceCollection StartBroker(this IServiceCollection services)
    {
        services.AddScoped<IRegisterHandler, RegisterHandlers>();
        services.AddScoped<IPublish, Publish>();
        services.AddScoped<IRepository, InMemoryRepository>();

        services.AddSingleton<IHostedService>(new StartEventsSubscriber(services));

        return services;
    }
}