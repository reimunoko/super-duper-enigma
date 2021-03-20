using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeService.EFMigration
{
    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {            
            IConfiguration configuration = new ConfigurationBuilder()
                                             .SetBasePath(System.IO.Path.Combine(System.IO.Path.GetFullPath("../EmployeeService")))
                                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)                                             
                                             .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
 
            optionsBuilder.UseSqlServer(
                                        configuration.GetConnectionString(nameof(EmployeeContext)),                                 
                                            b => b.MigrationsAssembly(typeof(EmployeeContextFactory).Assembly.FullName));

            optionsBuilder.UseSqlServer(
                                       configuration.GetConnectionString(nameof(EmployeeContext)),
                                           b => b.MigrationsAssembly(typeof(EmployeeContextFactory).Assembly.FullName));

            return new EmployeeContext(optionsBuilder.Options);
        }
    }

    public class LogContextFactory : IDesignTimeDbContextFactory<AppLogContext>
    {
        public AppLogContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                             .SetBasePath(System.IO.Path.Combine(System.IO.Path.GetFullPath("../EmployeeService")))
                                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                             .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppLogContext>();
              
            optionsBuilder.UseSqlServer(
                                       configuration.GetConnectionString(nameof(AppLogContext)),
                                           b => b.MigrationsAssembly(typeof(LogContextFactory).Assembly.FullName));

            return new AppLogContext(optionsBuilder.Options);
        }
    }

}
