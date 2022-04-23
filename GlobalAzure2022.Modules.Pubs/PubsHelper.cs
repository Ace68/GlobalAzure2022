using GlobalAzure2022.Modules.Pubs.Abstracts;
using GlobalAzure2022.Modules.Pubs.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Modules.Pubs;

public static class PubsHelper
{
    public static IServiceCollection AddPubs(this IServiceCollection services)
    {
        services.AddScoped<IPubsService, PubsService>();

        return services;
    }
}