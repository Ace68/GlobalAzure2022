using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public class PubsModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPubsService, PubsService>();

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