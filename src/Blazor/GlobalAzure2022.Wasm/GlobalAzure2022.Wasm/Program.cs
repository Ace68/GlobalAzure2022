using GlobalAzure2022.Wasm;
using GlobalAzure2022.Wasm.Modules.Production.Extensions;
using GlobalAzure2022.Wasm.Modules.Pubs.Extensions;
using GlobalAzure2022.Wasm.Modules.Suppliers.Extensions;
using GlobalAzure2022.Wasm.Shared.Configuration;
using GlobalAzure2022.Wasm.Shared.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using MudBlazor.Services;
using Serilog;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// httpClient is thread safe, and can be used safely many times by different threads.
// Dispose an httpClient instance forcibly closes the underlying TCP connection that is supposed to be pooled
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Configuration
builder.Services.AddSingleton(_ => builder.Configuration.GetSection("GlobalAzure2022:AppConfiguration")
    .Get<AppConfiguration>());
#endregion

#region DefaultServices
builder.Services.AddScoped<LazyAssemblyLoader>();
builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs\\Logs.log")
    .CreateLogger();
#endregion

#region Modules
builder.Services.AddApplicationService();

builder.Services.AddProduction();
builder.Services.AddPubs();
builder.Services.AddSuppliers();
#endregion

builder.Services.AddMudServices();

await builder.Build().RunAsync();