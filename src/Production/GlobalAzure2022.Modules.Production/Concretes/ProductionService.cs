using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Modules.Production.Concretes;

public class ProductionService : IProductionService
{
    public Task<ProductionGreetings> SayHelloAsync()
    {
        return Task.FromResult(new ProductionGreetings
        {
            Message = "Hello from Production"
        });
    }
}