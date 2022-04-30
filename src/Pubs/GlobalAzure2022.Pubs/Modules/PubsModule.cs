using GlobalAzure2022.Modules.Pubs;
using GlobalAzure2022.Modules.Pubs.Abstracts;
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
        endpoints.MapGet("/pubs/", async ([FromServices] IPubsService pubsService) => await pubsService.SayHelloAsync())
            .WithName("SayHelloFromPubs")
            .WithTags("Pubs");

        return endpoints;
    }
}