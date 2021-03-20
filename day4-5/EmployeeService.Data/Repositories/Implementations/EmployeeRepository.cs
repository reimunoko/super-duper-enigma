using System;
using System.Collections.Generic;
using System.Text;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Data;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class EmployeeRepository : AcmeEmployeeRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext dbContext) : base(dbContext)
        {
        }


    }
}
