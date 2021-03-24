using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.UI.Business.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient("department", c =>
            {
                c.BaseAddress = new Uri("https://localhost:44388/api/");
            });

            //services.AddHttpClient("fullsearch", c =>
            //{
            //    c.BaseAddress = new Uri("https://localhost:44388/api/department/fullsearch");
            //});

            return services;
        }
    }
}
