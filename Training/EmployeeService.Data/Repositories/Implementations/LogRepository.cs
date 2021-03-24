using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class LogRepository : BaseLogRepository<Log>, ILogRepository
    {
        public LogRepository(AppLogContext context) : base(context)
        {
        }

    }
}
