using GlobalAzure2022.Modules.Suppliers;
using GlobalAzure2022.Modules.Suppliers.Abstracts;

namespace GlobalAzure2022.Modules;

public class SuppliersModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddSuppliers();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/suppliers/", HandleSayHello)
            .WithName("SayHelloFromSuppliers")
            .WithTags("Suppliers");

        return endpoints;
    }

    private static async Task<IResult> HandleSayHello(ISupplierService supplierService)
    {
        var greetings = await supplierService.SayHelloAsync();
        return Results.Ok(greetings);
    }
}