using Babel.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMiddlewareAnalysisDiagnostics();
builder.Services.AddOpenApi();

var app = builder.Build();

app.ConsumeMiddlewareAnalysisDiagnostics();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
