using GlobalAzure2022.Wasm.Modules.Suppliers.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.Concretes;
using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Wasm.Modules.Suppliers.Extensions.Concretes;

public class SuppliersService : BaseHttpService, ISuppliersService
{
    public SuppliersService(HttpClient httpClient, IHttpService httpService, AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {

    }
}