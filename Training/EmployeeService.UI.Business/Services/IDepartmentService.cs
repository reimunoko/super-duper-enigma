using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.UI.Business.Model.Dto;

namespace EmployeeService.UI.Business.Services
{
    public interface IDepartmentService
    {
        Task<List<SearchDto>> Search(string keyword);

        Task<List<DepartmentDto>> GetAll(int currentPage, int pageSize);
        Task Add(DepartmentDto department);

        Task Update(DepartmentDto department);
        Task Delete(int id);
    }
}
