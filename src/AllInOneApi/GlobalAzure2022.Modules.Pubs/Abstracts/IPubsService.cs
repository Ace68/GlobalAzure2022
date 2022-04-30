namespace GlobalAzure2022.Modules.Pubs.Abstracts;

public interface IPubsService
{
    Task<string> SayHelloAsync();
}