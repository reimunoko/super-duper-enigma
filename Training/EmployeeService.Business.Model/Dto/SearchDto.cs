using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.UI.Model;

namespace EmployeeService.UI.Business.Model.Dto
{
    public class SearchDto
    {
        [AcmeGridColumn("Employee Name")]
        public string EmployeeName { get; set; }
        [AcmeGridColumn("Designation")]
        public string Designation { get; set; }
        [AcmeGridColumn("Department Name")]
        public string DepartmentName { get; set; }
        [AcmeGridColumn("Location")]
        public string Location { get; set; }

    }
 
}
