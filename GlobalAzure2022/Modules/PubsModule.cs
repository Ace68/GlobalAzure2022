using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public static class PubsModule
{
    public static IServiceCollection RegisterPubs(this IServiceCollection services)
    {
        services.AddScoped<IPubsService, PubsService>();

        return services;
    }

    public static IEndpointRouteBuilder MapPubs(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/pubs/", async ([FromServices] IPubsService pubsService) => await pubsService.SayHelloAsync())
            .WithName("SayHelloFromPubs")
            .WithTags("Pubs");

        return endpoints;
    }
}