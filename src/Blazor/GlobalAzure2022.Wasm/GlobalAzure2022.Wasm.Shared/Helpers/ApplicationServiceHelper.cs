using GlobalAzure2022.Wasm.Shared.Abstracts;
using GlobalAzure2022.Wasm.Shared.Concretes;
using GlobalAzure2022.Wasm.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure2022.Wasm.Shared.Helpers
{
    public static class ApplicationServiceHelper
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<ToastService>();

            services.AddSingleton<AppState>();

            return services;
        }
    }
}