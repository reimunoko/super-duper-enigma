using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Domain.Entities
{
    public class Log
    {        
        public int Id { get; set; }

        public string CorrelationId { get; set; }

        public string Level { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
             
    }
}
