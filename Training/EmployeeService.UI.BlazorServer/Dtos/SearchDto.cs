using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.UI.BlazorServer.Dtos
{
    public class SearchDto
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }

    }
 
}
