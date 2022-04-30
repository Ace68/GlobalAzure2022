using GlobalAzure2022.Services.Abstracts;

namespace GlobalAzure2022.Services.Concretes;

public class ProductionService : IProductionService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Production");
    }
}