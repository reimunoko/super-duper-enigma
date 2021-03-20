using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Implementations;
using EmployeeService.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Business.Configuration
{
    public static class BusinessServiceConfiguration
    {
        public static IServiceCollection AddBusinessServiceConfiguration(this IServiceCollection services)
        {
   
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
