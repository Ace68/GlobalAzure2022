using GlobalAzure2022.Wasm.Modules.Suppliers.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Modules.Suppliers.Extensions.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Wasm.Modules.Suppliers.Extensions;

public static class SuppliersHelper
{
    public static IServiceCollection AddSuppliers(this IServiceCollection services)
    {
        services.AddScoped<ISuppliersService, SuppliersService>();

        return services;
    }
}