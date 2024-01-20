using Microsoft.AspNetCore.Http;
using Serilog;
using System.Diagnostics;

namespace Dotnet.Core;

public class SerilogMiddleware
{
    private readonly RequestDelegate _next;

    public SerilogMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }

        if (httpContext.Request.Method == "OPTIONS")
        {
            await _next(httpContext);
        }
        else
        {
            var sw = Stopwatch.StartNew();

            try
            {
                var requestBodyStream = new MemoryStream();
                var originalRequestBody = httpContext.Request.Body;

                await httpContext.Request.Body.CopyToAsync(requestBodyStream);
                requestBodyStream.Seek(0, SeekOrigin.Begin);

                var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
                requestBodyText = requestBodyText.Substring(0, Math.Min(500, requestBodyText.Length));

                Log.Logger.Here().Information(
                    "HTTP {@httpMethod} Request For URL : {@url}, QueryString : {@query}, RequestBody : {@requestBody}",
                    httpContext.Request.Method, httpContext.Request.Path.Value, httpContext.Request.QueryString.Value, requestBodyText);

                requestBodyStream.Seek(0, SeekOrigin.Begin);
                httpContext.Request.Body = requestBodyStream;

                var bodyStream = httpContext.Response.Body;
                var responseBodyStream = new MemoryStream();
                httpContext.Response.Body = responseBodyStream;

                await _next(httpContext);
                sw.Stop();

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
                responseBody = responseBody.Substring(0, Math.Min(500, responseBody.Length));

                if (httpContext.Response.StatusCode > 499)
                {
                    Log.Logger.Here().Error(
                        "HTTP {@httpMethod} Responded in {Elapsed} ms For URL : {@url}, with StatusCode : {@statusCode}, ResponseBody : {@responseBody}",
                        httpContext.Request.Method, sw.ElapsedMilliseconds, httpContext.Request.Path.Value, httpContext.Response.StatusCode, responseBody);
                }
                else
                {
                    Log.Logger.Here().Information(
                        "HTTP {@httpMethod} Responded in {Elapsed} ms For URL : {@url}, with StatusCode : {@statusCode}, ResponseBody : {@responseBody}",
                        httpContext.Request.Method, sw.ElapsedMilliseconds, httpContext.Request.Path.Value, httpContext.Response.StatusCode, responseBody);
                }

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(bodyStream);

                httpContext.Request.Body = originalRequestBody;
            }
            catch (Exception ex) when (LogException(httpContext, sw, ex)) { }
        }
    }

    private static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
    {
        sw.Stop();
        Log.Logger.Here().Error("Serilog Middleware Exception {@ex}", ex);
        return false;
    }
}
