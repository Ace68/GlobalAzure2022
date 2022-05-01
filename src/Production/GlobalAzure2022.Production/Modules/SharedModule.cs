using GlobalAzure2022.Production.Shared;

namespace GlobalAzure2022.Production.Modules;

public class SharedModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddSharedServices();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}