using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }        
        public string DeptName { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
