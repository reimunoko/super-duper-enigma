using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Business.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;

        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task LogInformation(string correlationId, string message)
        {
            var log = new Log
            {
                Level = "INF",
                Message = message,
                CorrelationId = correlationId
            };
            await logRepository.AddAsync(log);
        }

        public async Task LogError(string correlationId, string message, string stackTrace)
        {
            var log = new Log
            {
                Level = "ERR",
                CorrelationId = correlationId,
                Message = message,
                StackTrace = stackTrace
            };
            await logRepository.AddAsync(log);
        }
    }
}
