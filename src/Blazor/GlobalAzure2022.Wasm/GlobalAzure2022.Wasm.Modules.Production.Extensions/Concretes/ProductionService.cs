using GlobalAzure2022.Wasm.Modules.Production.Extensions.Abstracts;
using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.Concretes;
using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Wasm.Modules.Production.Extensions.Concretes;

public class ProductionService : BaseHttpService, IProductionService
{
    public ProductionService(HttpClient httpClient, IHttpService httpService, AppConfiguration appConfiguration,
        ILoggerFactory loggerFactory) : base(httpClient, httpService, appConfiguration, loggerFactory)
    {

    }

    public async Task<string> SayHelloAsync()
    {
        try
        {
            return await HttpService.Get<string>(
                $"{AppConfiguration.ProductionApiUri}/");
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            return string.Empty;
        }
    }
}