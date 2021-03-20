using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data;
using EmployeeService.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeService.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
            
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;                  
        }

        public async Task Invoke(HttpContext httpContext, DbLogger dbLogger)
        {

            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await dbLogger.LogError(httpContext.TraceIdentifier, ex.Message, ex.StackTrace);
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync("Something went wrong, we will get back to you as soon as we can.");

            }                       
        }
    }
}
