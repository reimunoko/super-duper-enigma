using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Data.Repositories.Interfaces
{
    public interface IDepartmentRespository : IBaseRepository<Department>
    {

        IEnumerable<Department> GetDepartmentEmployeesByLocation(string location);

        IEnumerable<Department> GetDepartmentEmployeesByName(string name);

        IEnumerable<Department> GetDepartmentEmployeesByNameAndLocation(string name, string location);        

    }
}
