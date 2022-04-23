using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public static class ProductionModule
{
    public static IServiceCollection RegisterProduction(this IServiceCollection services)
    {
        services.AddScoped<IProductionService, ProductionService>();

        return services;
    }

    public static IEndpointRouteBuilder MapProduction(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/production/", async ([FromServices] IProductionService productionService) => await productionService.SayHelloAsync())
            .WithName("SayHelloFromProduction")
            .WithTags("Production");

        return endpoints;
    }
}