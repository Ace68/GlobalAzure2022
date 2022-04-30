using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Modules.Production.Concretes;

public class ProductionService : IProductionService
{
    public Task<ProductionGreetings> SayHelloAsync(GreetingsRequest request)
    {
        return Task.FromResult(new ProductionGreetings
        {
            Message = $"Hello {request.Name} from Production"
        });
    }
}