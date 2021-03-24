using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data.Repositories.Interfaces;

namespace EmployeeService.Business.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDepartmentRespository departmentRespository;

        public EmployeeService(IDepartmentRespository departmentRespository)
        {
            this.departmentRespository = departmentRespository;
        }

 
    }
}
