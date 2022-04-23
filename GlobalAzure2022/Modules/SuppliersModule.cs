using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public class SuppliersModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISupplierService, SupplierService>();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/suppliers/", async ([FromServices] ISupplierService supplierService) => await supplierService.SayHelloAsync())
            .WithName("SayHelloFromSuppliers")
            .WithTags("Suppliers");

        return endpoints;
    }
}