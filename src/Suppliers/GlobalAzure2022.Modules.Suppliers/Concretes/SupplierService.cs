using GlobalAzure2022.Modules.Suppliers.Abstracts;

namespace GlobalAzure2022.Modules.Suppliers.Concretes;

public class SupplierService : ISupplierService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Suppliers");
    }
}