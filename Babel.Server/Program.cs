using System.Diagnostics;
using Babel.Server.Diagnostics;
using Microsoft.AspNetCore.MiddlewareAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.Insert(0, ServiceDescriptor.Transient<IStartupFilter, AnalysisStartupFilter>());

var app = builder.Build();

var listener = app.Services.GetRequiredService<DiagnosticListener>();
var adapter = ActivatorUtilities.CreateInstance<MiddlewareAnalysisDiagnosticAdapter>(app.Services);
listener.SubscribeWithAdapter(adapter);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
