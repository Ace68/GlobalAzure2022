using FluentValidation;
using GlobalAzure2022.Modules.Production;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;

namespace GlobalAzure2022.Production.Modules;

public class ProductionModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddProduction(builder.Configuration["BrewUp:ServiceBus:ConnectionString"]);

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/production/", HandleSayHelloAsync)
            .WithName("SayHelloFromProduction")
            .WithTags("Production");

        endpoints.MapPost("/production/Beers", HandlePostBrewBeer)
            .WithName("BrewBeer")
            .WithTags("Production");

        endpoints.MapGet("/production/Beers", HandleGetBeers)
            .WithName("GetBeers")
            .WithTags("Production");

        return endpoints;
    }

    private static async Task<IResult> HandleSayHelloAsync(GreetingsRequest request,
        IProductionService productionService, IValidator<GreetingsRequest> validator)
    {
        try
        {
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
                return Results.Ok(await productionService.SayHelloAsync(request));

            var errors = validationResult.Errors.GroupBy(e => e.PropertyName)
                .ToDictionary(k => k.Key, v => v.Select(e => e.ErrorMessage).ToArray());
            return Results.ValidationProblem(errors);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> HandleGetBeers(IProductionService productionService)
    {
        try
        {
            var beers = await productionService.GetBeersAsync();
            return Results.Ok(beers);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> HandlePostBrewBeer(BeersJson brewBeer, IProductionService productionService,
        IValidator<BeersJson> validator)
    {
        try
        {
            var validationResult = await validator.ValidateAsync(brewBeer);
            if (validationResult.IsValid)
            {
                await productionService.PrepareBeerAsync(brewBeer);
                return Results.Accepted();
            }

            var errors = validationResult.Errors.GroupBy(e => e.PropertyName)
                .ToDictionary(k => k.Key, v => v.Select(e => e.ErrorMessage).ToArray());
            return Results.ValidationProblem(errors);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.BadRequest(ex.Message);
        }
    }
}