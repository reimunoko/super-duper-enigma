using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using EmployeeService.Utilities;

namespace EmployeeService.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;
      
        private readonly IServiceProvider provider;
      

        public RequestLoggerMiddleware(RequestDelegate next, IServiceProvider provider)
        {
            this.next = next;
            this.provider = provider;
        }

        public async Task Invoke(HttpContext httpContext)
        {
           var requestHeaders = httpContext.Request.Headers.ToDictionary(hc => hc.Key, hc => hc.Value.ToString());
            
            using (var scope = provider.CreateScope())
            {
                var dbLogger = scope.ServiceProvider.GetRequiredService<DbLogger>();
                await dbLogger.LogInformation(httpContext.TraceIdentifier, $"Request { httpContext.Request.Method} {httpContext.Request.Path} {httpContext.Request.QueryString}");
                await dbLogger.LogInformation(httpContext.TraceIdentifier, System.Text.Json.JsonSerializer.Serialize(requestHeaders));
            }

            await next(httpContext);

            using (var scope = provider.CreateScope())
            {
                var dbLogger = scope.ServiceProvider.GetRequiredService<DbLogger>();
                await dbLogger.LogInformation(httpContext.TraceIdentifier, $"Response { httpContext.Request.Method} {httpContext.Request.Path} {httpContext.Response.StatusCode}");           
            }
        }
    }
}
