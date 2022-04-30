using System.Net.Http;
using GlobalAzure2022.Modules.Pubs.Abstracts;
using GlobalAzure2022.Modules.Pubs.Concretes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GlobalAzure2022.Pubs.Tests
{
    public abstract class BaseTest
    {
        protected HttpClient Client;

        protected BaseTest()
        {
            var application = new GlobalAzureApplication();
            Client = application.CreateClient();
        }

        private class GlobalAzureApplication : WebApplicationFactory<Program>
        {
            protected override IHost CreateHost(IHostBuilder builder)
            {
                builder.ConfigureServices(services =>
                {
                    services.AddLogging();
                    
                    services.AddScoped<IPubsService, PubsService>();
                });

                return base.CreateHost(builder);
            }
        }
    }
}