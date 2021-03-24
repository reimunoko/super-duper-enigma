using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Domain.Entities;
using EmployeeService.UI.Business.Model.Dto;

namespace EmployeeService.Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentIdSearchDto> GetDepartmentEmployees(string Id);
        List<DepartmentEmployeeSearchDto> GetDepartmentEmployees(string name, string location);

        Task<IReadOnlyList<DepartmentDto>> GetDepartments();

        List<SearchDto> GetAllByKeyword(string keyword);

        Task Add(DepartmentDto department);
        Task Update(DepartmentDto department);

        Task Delete(int id);


    }
}
