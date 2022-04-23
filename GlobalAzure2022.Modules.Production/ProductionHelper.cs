using GlobalAzure2022.Concretes;
using GlobalAzure2022.Modules.Production.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Modules.Production;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();

        return services;
    }
}