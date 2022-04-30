using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

namespace GlobalAzure2022.Wasm;

public class AppBase : ComponentBase, IDisposable
{
    [Inject] private LazyAssemblyLoader AssemblyLoader { get; set; }
    [Inject] private ILogger<App> Logger { get; set; }

    protected readonly List<Assembly> LazyLoadedAssemblies = new();

    protected async Task OnNavigateAsync(NavigationContext args)
    {
        try
        {
            switch (args.Path)
            {
                case "production":
                {
                    var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                    {
                        "GlobalAzure2022.Wasm.Modules.Production.dll"
                    });
                    LazyLoadedAssemblies.AddRange(assemblies);
                    break;
                }

                case "pubs":
                {
                    var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                    {
                        "GlobalAzure2022.Wasm.Modules.Pubs.dll"
                    });
                    LazyLoadedAssemblies.AddRange(assemblies);
                    break;
                }

                case "suppliers":
                {
                    var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                    {
                        "GlobalAzure2022.Wasm.Modules.Suppliers.dll"
                    });
                    LazyLoadedAssemblies.AddRange(assemblies);
                    break;
                }

                // We need to load GlobalAzure2022.Wasm.Modules.Desktop.dll at startup
                default:
                    {
                        var assemblies = await AssemblyLoader.LoadAssembliesAsync(new List<string>
                    {
                        "GlobalAzure2022.Wasm.Modules.Desktop.dll"
                    });
                        LazyLoadedAssemblies.AddRange(assemblies);
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error Loading page: {ex}");
        }
    }

    #region Dispose
    public void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~AppBase()
    {
        Dispose(false);
    }
    #endregion
}