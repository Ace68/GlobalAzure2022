using System.Net.Http;
using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobalAzure2022.Wasm.Shared.Concretes
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient HttpClient;
        protected readonly IHttpService HttpService;
        protected readonly AppConfiguration AppConfiguration;
        protected readonly ILogger Logger;

        protected BaseHttpService(HttpClient httpClient,
            IHttpService httpService,
            AppConfiguration appConfiguration,
            ILoggerFactory loggerFactory)
        {
            this.HttpClient = httpClient;
            this.HttpService = httpService;
            this.AppConfiguration = appConfiguration;
            this.Logger = loggerFactory.CreateLogger(this.GetType());
        }
    }
}