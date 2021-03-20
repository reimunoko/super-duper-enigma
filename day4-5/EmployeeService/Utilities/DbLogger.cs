using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data;

namespace EmployeeService.Utilities
{
    public class DbLogger
    {
        private readonly EmployeeContext context;

        public DbLogger(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task LogInformation(string correlationId, string message)
        {
            var log = new Domain.Entities.Log();
            log.Level = "INF";
            log.Message = message;
            log.CorrelationId = correlationId;
            await context.Logs.AddAsync(log);
            await context.SaveChangesAsync();
        }

        public async Task LogError(string correlationId, string message, string stackTrace)
        {
            var log = new Domain.Entities.Log();
            log.Level = "ERR";
            log.CorrelationId = correlationId;
            log.Message = message;
            log.StackTrace = stackTrace;
            await context.Logs.AddAsync(log);
            await context.SaveChangesAsync();

        }
    }
}
