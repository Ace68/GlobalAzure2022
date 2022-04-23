using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductionService, ProductionService>();
builder.Services.AddScoped<IPubsService, PubsService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

var app = builder.Build();

app.MapGet("/production/", async ([FromServices] IProductionService productionService) => await productionService.SayHelloAsync())
    .WithName("SayHelloFromProduction")
    .WithTags("Production");

app.MapGet("/pubs/", async ([FromServices] IPubsService pubsService) => await pubsService.SayHelloAsync())
    .WithName("SayHelloFromPubs")
    .WithTags("Pubs");

app.MapGet("/suppliers/", async ([FromServices] ISupplierService supplierService) => await supplierService.SayHelloAsync())
    .WithName("SayHelloFromSuppliers")
    .WithTags("Suppliers");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();