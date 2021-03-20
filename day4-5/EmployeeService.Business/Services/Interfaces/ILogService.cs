using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Business.Services.Interfaces
{
    public interface ILogService
    {
        Task LogInformation(string correlationId, string message);
        Task LogError(string correlationId, string message, string stackTrace);
    }
}
