using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeService.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
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
                                            b => b.MigrationsAssembly(typeof(ContextFactory).Assembly.FullName));

            return new EmployeeContext(optionsBuilder.Options);
        }
    }

    
}
