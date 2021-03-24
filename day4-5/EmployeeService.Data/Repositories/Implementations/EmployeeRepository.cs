using System;
using System.Collections.Generic;
using System.Text;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Data;
using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class EmployeeRepository : AcmeEmployeeRepository<Employee>, IEmployeeRepository
    {
        private readonly EmployeeContext dbContext;

        public EmployeeRepository(EmployeeContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

         
    }
}
