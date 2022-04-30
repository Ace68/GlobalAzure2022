using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Modules.Production.Abstracts;

public interface IProductionService
{
    Task<ProductionGreetings> SayHelloAsync();
}