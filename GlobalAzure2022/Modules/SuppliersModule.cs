using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAzure2022.Modules;

public static class SuppliersModule
{
    public static IServiceCollection RegisterSuppliers(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();

        return services;
    }

    public static IEndpointRouteBuilder MapSuppliers(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/suppliers/", async ([FromServices] ISupplierService supplierService) => await supplierService.SayHelloAsync())
            .WithName("SayHelloFromSuppliers")
            .WithTags("Suppliers");

        return endpoints;
    }
}