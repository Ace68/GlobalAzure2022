using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public class ProductionModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductionService, ProductionService>();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/production/", async ([FromServices] IProductionService productionService) => await productionService.SayHelloAsync())
            .WithName("SayHelloFromProduction")
            .WithTags("Production");

        return endpoints;
    }
}