using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Dto;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository departmentRespository;

        public DepartmentService(IDepartmentRespository departmentRespository)
        {
            this.departmentRespository = departmentRespository;
        }

      
        public async Task<DepartmentIdSearchDto> GetDepartmentEmployees(string Id)
        {
            var isValid = Int32.TryParse(Id, out int result);
            if (!isValid)
            {
                throw new ArgumentException("Department id must be numeric");
            }
            else if (result < 0)
            {
                throw new ArgumentException("Department id cannot be less than zero");
            }
            else
            {
                var data = await departmentRespository.GetByIdAsync(result);

                return new DepartmentIdSearchDto() { DepartmentId = data.Id, Location = data.DeptName, Name = data.DeptName } ;
            }
        }

        public List<DepartmentEmployeeSearchDto> GetDepartmentEmployees(string name, string location)
        {
            var loc = location ?? string.Empty;
            var departmentName = name ?? string.Empty;

            IEnumerable<Department> departments = null;

            if (name == null && location != null)
            {
                departments =  departmentRespository.GetDepartmentEmployeesByLocation(loc);                              
            }
            else if (location == null && name != null)
            {
                departments = departmentRespository.GetDepartmentEmployeesByName(loc);
            }            
            else
            {
                departments = departmentRespository.GetDepartmentEmployeesByNameAndLocation(departmentName, loc);
            }

            return departments.Select(x => new DepartmentEmployeeSearchDto()
            {
                DepartmentId = x.Id,
                Location = x.Location,
                Name = x.DeptName,
                Employees = x.Employees.Select(e => new EmployeeSearchDto() { EmployeeName = e.EmpName, Designation = e.Designation })
            }).ToList();
        }

        public async Task<IReadOnlyList<Department>> GetDepartmentEmployees()
        {
           return await departmentRespository.ListAllAsync();
        }
    }
}
