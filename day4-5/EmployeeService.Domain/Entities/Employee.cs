using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Entities
{
    public class Employee
    {       
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }   
        
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
