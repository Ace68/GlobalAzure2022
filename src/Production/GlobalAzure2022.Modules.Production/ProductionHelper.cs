using FluentValidation.AspNetCore;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Modules.Production;

public static class ProductionHelper
{
    public static IServiceCollection AddProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();
        services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ProductionService>());

        return services;
    }
}