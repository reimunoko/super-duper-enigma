using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data;

namespace EmployeeService.Utilities
{
    public class DbLogger
    {
        private readonly ILogService logService;

        public DbLogger(ILogService logService)
        {
            this.logService = logService;
        }

        public async Task LogInformation(string correlationId, string message)
        {
            await logService.LogInformation(correlationId, message);
        }

        public async Task LogError(string correlationId, string message, string stackTrace)
        {
            await logService.LogError(correlationId, message, stackTrace);

        }
    }
}
