using Microsoft.Extensions.DiagnosticAdapter;

namespace Babel.Server.Diagnostics;

public class MiddlewareAnalysisDiagnosticAdapter
{
    private readonly ILogger<MiddlewareAnalysisDiagnosticAdapter> _logger;

    public MiddlewareAnalysisDiagnosticAdapter(ILogger<MiddlewareAnalysisDiagnosticAdapter> logger)
    {
        _logger = logger;
    }

    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareStarting")]
    public void OnMiddlewareStarting(string name, HttpContext httpContext, Guid instanceId, long timestamp)
    {
        _logger.LogInformation($"MiddlewareStarting: '{name}'; Request Path: '{httpContext.Request.Path}'");
    }

    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareFinished")]
    public void OnMiddlewareFinished(string name, HttpContext httpContext, Guid instanceId, long timestamp, long duration)
    {
        _logger.LogInformation($"MiddlewareFinished: '{name}'; Status: '{httpContext.Response.StatusCode}'");
    }

    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareException")]
    public void OnMiddlewareException(string name, HttpContext httpContext, Guid instanceId, long timestamp, long duration, Exception exception)
    {
        _logger.LogInformation($"MiddlewareException: '{name}'; '{exception.Message}'");
    }
}