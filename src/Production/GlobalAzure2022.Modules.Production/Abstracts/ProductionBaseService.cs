using GlobalAzure2022.Production.ReadModel.Abstracts;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Modules.Production.Abstracts;

public abstract class ProductionBaseService
{
    protected IPersister Persister;
    protected ILogger Logger;

    protected ProductionBaseService(IPersister persister, ILoggerFactory loggerFactory)
    {
        Persister = persister;
        Logger = loggerFactory.CreateLogger(GetType());
    }
}