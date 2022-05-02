using GlobalAzure2022.Production.Mediator;

namespace GlobalAzure2022.Production.Modules;

public class MediatorModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 99;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddDomainProcessor(builder.Configuration["BrewUp:ServiceBus:ConnectionString"]);
        builder.Services.StartBroker();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}