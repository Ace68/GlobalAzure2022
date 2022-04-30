using GlobalAzure2022.Production.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterModules();

var app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();