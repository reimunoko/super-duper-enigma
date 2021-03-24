using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Dto;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentIdSearchDto> GetDepartmentEmployees(string Id);
        List<DepartmentEmployeeSearchDto> GetDepartmentEmployees(string name, string location);

        Task<IReadOnlyList<Department>> GetDepartmentEmployees();

       List<SearchDto> GetAllByKeyword(string keyword);
    }
}
