using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Business.Services.Interfaces;
using EmployeeService.Data;
using EmployeeService.Domain.Entities;
using EmployeeService.UI.Business.Model.Dto;
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

        //[HttpGet]
        //[EnableQuery(PageSize = 100, EnsureStableOrdering = false)]
        //public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        //{
        //    return await departmentService.GetDepartments();

        //}

        [HttpGet]
        public async Task<IActionResult> GetDepartments(int currentPage, int pageSize)
        {
            return Ok(await departmentService.GetDepartments(currentPage, pageSize));
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

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto department)
        {
            await departmentService.Add(department);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto department)
        {
            await departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>  DeleteDepartment(int id)
        {
            await departmentService.Delete(id);
            return NoContent();
        }
    }
}
