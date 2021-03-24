using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Domain.Entities;
using EmployeeService.UI.Business.Model.Dto;

namespace EmployeeService.Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository departmentRespository;

        public DepartmentService(IDepartmentRespository departmentRespository)
        {
            this.departmentRespository = departmentRespository;
        }

        public async Task Add(DepartmentDto department)
        { 
            //AutoMapper
            Department entity = new Department()
            {
                
                DeptName = department.Name,
                Location = department.Location,

            };

            await departmentRespository.AddAsync(entity);
        }

         

        public async Task Delete(int id)
        {
            
            await departmentRespository.DeleteAsync(id);
        }

        public List<SearchDto> GetAllByKeyword(string keyword)
        {
            return this.departmentRespository.GetAll(keyword).Select(x => BuildData(x.Employees.First(e => e.DepartmentId == x.Id), x.DeptName, x.Location)).ToList();

            SearchDto BuildData(Employee e, string deptName, string location)
            {
                return new SearchDto() { EmployeeName = e.EmpName, Designation = e.Designation, DepartmentName = deptName, Location = location };
            }
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

        public async Task<IReadOnlyList<DepartmentDto>> GetDepartments()
        {
           var departments = await departmentRespository.ListAllAsync();
           return departments.Select(s => new DepartmentDto() { Id = s.Id, Name = s.DeptName, Location = s.Location }).ToList();
        }

        public async Task Update(DepartmentDto department)
        {
            //AutoMapper

            Department entity = new Department()
            {
                Id = department.Id,
                DeptName = department.Name,
                Location = department.Location,

            };

            await departmentRespository.UpdateAsync(entity);          
        }
    }
}
