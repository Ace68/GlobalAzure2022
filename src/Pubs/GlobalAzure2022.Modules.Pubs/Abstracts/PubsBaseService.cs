using GlobalAzure2022.Pubs.ReadModel.Abstracts;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Modules.Pubs.Abstracts;

public abstract class PubsBaseService
{
    protected readonly IPersister Persister;
    protected readonly ILogger Logger;

    protected PubsBaseService(IPersister persister, ILoggerFactory loggerFactory)
    {
        Persister = persister;
        Logger = loggerFactory.CreateLogger(GetType());
    }
}