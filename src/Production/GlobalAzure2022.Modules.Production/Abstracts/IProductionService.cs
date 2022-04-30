namespace GlobalAzure2022.Modules.Production.Abstracts;

public interface IProductionService
{
    Task<string> SayHelloAsync();
}