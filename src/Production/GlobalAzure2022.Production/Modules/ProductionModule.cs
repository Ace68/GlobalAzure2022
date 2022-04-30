using GlobalAzure2022.Modules.Production;
using GlobalAzure2022.Modules.Production.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Production.Modules;

public class ProductionModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddProduction();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/production/", HandleSayHelloAsync)
            .WithName("SayHelloFromProduction")
            .WithTags("Production");

        return endpoints;
    }

    private static async Task<IResult> HandleSayHelloAsync(IProductionService productionService)
    {
        try
        {
            var greetings = await productionService.SayHelloAsync();

            return Results.Ok(greetings);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}