using GlobalAzure2022.Wasm.Modules.Production.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Modules.Production.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Wasm.Modules.Production.Extensions;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();

        return services;
    }
}