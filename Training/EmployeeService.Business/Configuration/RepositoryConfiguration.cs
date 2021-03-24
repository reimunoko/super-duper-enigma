using System;
using System.Collections.Generic;
using System.Text;
using EmployeeService.Data.Repositories.Implementations;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Business.Configuration
{
    public static class RepositoryConfiguration
    {

        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Department>, AcmeEmployeeRepository<Department>>();
            services.AddScoped<IBaseRepository<Employee>, AcmeEmployeeRepository<Employee>>();
            services.AddScoped<IBaseRepository<Log>, BaseLogRepository<Log>>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRespository, DepartmentRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            return services;
        }
    }
}
