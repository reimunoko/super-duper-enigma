using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Data;
using EmployeeService.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext context;

        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [EnableQuery(PageSize = 25, EnsureStableOrdering = false)]
        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;

        }
    }
}
