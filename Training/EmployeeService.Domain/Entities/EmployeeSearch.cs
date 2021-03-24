using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeService.Domain.Entities
{
    public class EmployeeSearch
    {
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

    }
}
