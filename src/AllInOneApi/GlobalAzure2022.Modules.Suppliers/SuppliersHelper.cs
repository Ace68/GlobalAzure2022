using GlobalAzure2022.Modules.Suppliers.Abstracts;
using GlobalAzure2022.Modules.Suppliers.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Modules.Suppliers;

public static class SuppliersHelper
{
    public static IServiceCollection AddSuppliers(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();

        return services;
    }
}