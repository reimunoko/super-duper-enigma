using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.UI.Business.Dtos;

namespace EmployeeService.UI.Business.Services
{
    public interface IDepartmentService
    {
        Task<List<SearchDto>> Search(string keyword);
    }
}
