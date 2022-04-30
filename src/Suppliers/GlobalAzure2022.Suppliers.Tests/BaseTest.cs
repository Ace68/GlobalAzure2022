using System.Net.Http;
using GlobalAzure2022.Modules.Suppliers.Abstracts;
using GlobalAzure2022.Modules.Suppliers.Concretes;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GlobalAzure2022.Suppliers.Tests
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
                    
                    services.AddScoped<ISupplierService, SupplierService>();
                });

                return base.CreateHost(builder);
            }
        }
    }
}