using GlobalAzure2022.Wasm.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Wasm.Modules.Production.Extensions.Abstracts;

public interface IProductionService
{
    Task<ProductionGreetings> SayHelloAsync();
}