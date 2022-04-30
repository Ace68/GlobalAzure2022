using GlobalAzure2022.Modules.Production.Abstracts;

namespace GlobalAzure2022.Concretes;

public class ProductionService : IProductionService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Production");
    }
}