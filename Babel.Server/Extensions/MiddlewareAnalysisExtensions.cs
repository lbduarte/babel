using System.Diagnostics;
using Babel.Server.Diagnostics;
using Microsoft.AspNetCore.MiddlewareAnalysis;

namespace Babel.Server.Extensions;

public static class MiddlewareAnalysisExtensions
{
    public static IServiceCollection AddMiddlewareAnalysisDiagnostics(this IServiceCollection services)
    {
        services.Insert(0, ServiceDescriptor.Transient<IStartupFilter, AnalysisStartupFilter>());

        return services;
    }

    public static WebApplication ConsumeMiddlewareAnalysisDiagnostics(this WebApplication app)
    {
        var listener = app.Services.GetRequiredService<DiagnosticListener>();
        var adapter = ActivatorUtilities.CreateInstance<MiddlewareAnalysisDiagnosticAdapter>(app.Services);
        listener.SubscribeWithAdapter(adapter);

        return app;
    }
}
