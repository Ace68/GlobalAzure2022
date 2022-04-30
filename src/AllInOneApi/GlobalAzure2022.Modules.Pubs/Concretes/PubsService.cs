using GlobalAzure2022.Modules.Pubs.Abstracts;

namespace GlobalAzure2022.Modules.Pubs.Concretes;

public class PubsService : IPubsService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Pubs");
    }
}