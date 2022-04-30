using GlobalAzure2022.Wasm.Modules.Pubs.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.Concretes;
using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Wasm.Modules.Pubs.Extensions.Concretes;

public class PubsService : BaseHttpService, IPubsService
{
    public PubsService(HttpClient httpClient, IHttpService httpService, AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {

    }
}