using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Wasm.Shared.Concretes
{
    public abstract class BaseService
    {
        protected ILogger Logger;
        protected AppConfiguration AppConfiguration;

        protected BaseService(ILoggerFactory loggerFactory,
            AppConfiguration appConfiguration)
        {
            this.AppConfiguration = appConfiguration;
            this.Logger = loggerFactory.CreateLogger(this.GetType());
        }
    }
}