using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class DepartmentRepository : AcmeEmployeeRepository<Department>, IDepartmentRespository
    {
        private readonly EmployeeContext context;

        public DepartmentRepository(EmployeeContext context) : base(context)
        {
            this.context = context;
        }


        public IEnumerable<Department> GetDepartmentEmployeesByLocation(string location)
        {
            return context.Departments.AsNoTracking().Where(d =>
               d.Location.Contains(location)).Include("Employees").AsEnumerable();
                 
        }

        public IEnumerable<Department> GetDepartmentEmployeesByNameAndLocation(string name, string location)
        {
            return context.Departments.AsNoTracking().Where(d => d.Location.Contains(location) 
                                && d.DeptName.Contains(name)).Include("Employees").AsEnumerable();
        }

        public IEnumerable<Department> GetDepartmentEmployeesByName(string name)
        {
            return context.Departments.AsNoTracking()
                  .Where(d => d.DeptName.Contains(name)).Include("Employees").AsEnumerable();
        }

        public IEnumerable<Department> GetAll(string keyword)
        {
           
          return context.Departments.AsNoTracking()
                        .Where(d => d.Location.Contains(keyword) || 
                         d.DeptName.Contains(keyword) ||
                         d.Employees.Any(x => x.EmpName.Contains(keyword))).Include("Employees").AsEnumerable();                
        }
    }
}
