using GlobalAzure2022.Wasm.Modules.Production.Extensions.Abstracts;
using Microsoft.AspNetCore.Components;

namespace GlobalAzure2022.Wasm.Modules.Production;

public class ProductionBase : ComponentBase, IDisposable
{
    [Inject] IProductionService ProductionService { get; set; }

    protected string Greetings = string.Empty;

    protected async Task SayHello()
    {
        try
        {
            Greetings = await ProductionService.SayHelloAsync();
        }
        catch (Exception ex)
        {
            Greetings = ex.Message;
            throw;
        }

        StateHasChanged();
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

    ~ProductionBase()
    {
        Dispose(false);
    }
    #endregion
}