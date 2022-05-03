using GlobalAzure2022.Modules.Pubs;
using GlobalAzure2022.Modules.Pubs.Abstracts;
using GlobalAzure2022.Pubs.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Pubs.Modules;

public class PubsModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddPubs();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/pubs/", HandleSayHello)
            .WithName("SayHelloFromPubs")
            .WithTags("Pubs");

        endpoints.MapGet("/pubs/Beers", HandleGetBeers)
            .WithName("GetBeers")
            .WithTags("Pubs");

        return endpoints;
    }

    private static async Task<IResult> HandleSayHello(IPubsService pubsService)
    {
        try
        {
            return Results.Ok(await pubsService.SayHelloAsync());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private static async Task<IResult> HandleGetBeers(IPubsService pubsService)
    {
        try
        {
            var beers = await pubsService.GetBeersAsync();
            return Results.Ok(beers);
        }
        catch (Exception ex)
        {
            Console.WriteLine(CommonServices.GetDefaultErrorTrace(ex));
            return Results.BadRequest(CommonServices.GetErrorMessage(ex));
        }
    }
}