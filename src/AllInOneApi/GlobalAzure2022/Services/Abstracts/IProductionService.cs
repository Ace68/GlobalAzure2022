namespace GlobalAzure2022.Services.Abstracts;

public interface IProductionService
{
    Task<string> SayHelloAsync();
}