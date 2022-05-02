using GlobalAzure2022.Production.ReadModel.MongoDb;
using GlobalAzure2022.Production.Shared.Configuration;

namespace GlobalAzure2022.Production.Modules;

public class MongoDbModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 1;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        var mongoDbParameters = new MongoDbParameters();
        builder.Configuration.GetSection("BrewUp:MongoDbParameters").Bind(mongoDbParameters);
        builder.Services.AddMongoDb(mongoDbParameters);
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}