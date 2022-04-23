using GlobalAzure2022.Abstracts;

namespace GlobalAzure2022.Concretes;

public class ProductionService : IProductionService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Production");
    }
}