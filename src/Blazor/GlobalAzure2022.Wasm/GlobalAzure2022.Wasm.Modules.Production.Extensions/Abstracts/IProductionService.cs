namespace GlobalAzure2022.Wasm.Modules.Production.Extensions.Abstracts;

public interface IProductionService
{
    Task<string> SayHelloAsync();
}