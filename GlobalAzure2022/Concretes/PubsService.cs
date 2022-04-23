using GlobalAzure2022.Abstracts;

namespace GlobalAzure2022.Concretes;

public class PubsService : IPubsService
{
    public Task<string> SayHelloAsync()
    {
        return Task.FromResult("Hello from Pubs");
    }
}