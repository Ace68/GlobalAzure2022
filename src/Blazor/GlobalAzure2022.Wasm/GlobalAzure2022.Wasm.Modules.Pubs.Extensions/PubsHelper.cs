using GlobalAzure2022.Wasm.Modules.Pubs.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Modules.Pubs.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Wasm.Modules.Pubs.Extensions;

public static class PubsHelper
{
    public static IServiceCollection AddPubs(this IServiceCollection services)
    {
        services.AddScoped<IPubsService, PubsService>();

        return services;
    }
}