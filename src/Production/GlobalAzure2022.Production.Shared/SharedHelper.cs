using GlobalAzure2022.Production.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Muflone;

namespace GlobalAzure2022.Production.Shared;

public static class SharedHelper
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceBus, InProcessServiceBus>();

        return services;
    }
}