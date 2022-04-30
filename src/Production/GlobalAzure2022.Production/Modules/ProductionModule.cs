using FluentValidation;
using GlobalAzure2022.Modules.Production;
using GlobalAzure2022.Modules.Production.Abstracts;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

namespace GlobalAzure2022.Production.Modules;

public class ProductionModule : IModule
{
    public bool IsEnabled { get; } = true;
    public int Order { get; } = 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddProduction();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/production/", HandleSayHelloAsync)
            .WithName("SayHelloFromProduction")
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
            throw;
        }
    }
}