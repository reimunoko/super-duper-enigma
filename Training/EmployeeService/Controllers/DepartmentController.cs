using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data;
using EmployeeService.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {

            this.departmentService = departmentService;
        }

        [HttpGet]
        [EnableQuery(PageSize = 25, EnsureStableOrdering = false)]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await departmentService.GetDepartmentEmployees();

        }

        [HttpGet("search/{Id}")]
        public async Task<IActionResult> GetDepartments(string Id)
        {            
            return Ok(await departmentService.GetDepartmentEmployees(Id));
        } 

        [HttpGet("search")]
        public IActionResult GetDepartments(string location, string deptName)
        {
            return Ok(departmentService.GetDepartmentEmployees(deptName, location));
        }

        [HttpGet("fullsearch")]
        public IActionResult GetAll(string keyword)
        {
            return Ok(departmentService.GetAllByKeyword(keyword));
        }
    }
}
