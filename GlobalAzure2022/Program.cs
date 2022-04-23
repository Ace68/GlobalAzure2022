using GlobalAzure2022.Abstracts;
using GlobalAzure2022.Concretes;
using GlobalAzure2022.Modules;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterProduction();
builder.Services.RegisterPubs();
builder.Services.RegisterSuppliers();

var app = builder.Build();

app.MapProduction();
app.MapPubs();
app.MapSuppliers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();