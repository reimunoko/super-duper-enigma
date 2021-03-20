using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Business.Dto
{
    public class DepartmentIdSearchDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

    }

    public class DepartmentEmployeeSearchDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
     
        public IEnumerable<EmployeeSearchDto> Employees { get; set; }
    }

    public class EmployeeSearchDto
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
    }

}
