using Microsoft.Extensions.DiagnosticAdapter;

namespace Babel.Server.Diagnostics;

public class MiddlewareDiagnosticListener
{
    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareStarting")]
    public virtual void OnMiddlewareStarting(HttpContext httpContext, string name)
    {
        Console.WriteLine($"MiddlewareStarting: {name}; {httpContext.Request.Path}");
    }

    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareException")]
    public virtual void OnMiddlewareException(Exception exception, string name)
    {
        Console.WriteLine($"MiddlewareException: {name}; {exception.Message}");
    }

    [DiagnosticName("Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareFinished")]
    public virtual void OnMiddlewareFinished(HttpContext httpContext, string name)
    {
        Console.WriteLine($"MiddlewareFinished: {name}; {httpContext.Response.StatusCode}");
    }
}