using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.UI.BlazorServer.Dtos;

namespace EmployeeService.UI.BlazorServer.Services
{
    public interface IDepartmentService
    {
        Task<List<SearchDto>> Search(string keyword);
    }
}
