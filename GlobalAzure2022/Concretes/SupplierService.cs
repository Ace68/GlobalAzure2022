using GlobalAzure2022.Abstracts;

namespace GlobalAzure2022.Concretes;

public class SupplierService : ISupplierService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Suppliers");
    }
}