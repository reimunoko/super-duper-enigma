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
        private readonly EmployeeContext context;
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {

            this.departmentService = departmentService;
        }

        //[HttpGet]
        //[EnableQuery(PageSize = 25, EnsureStableOrdering = false)]
        //public IEnumerable<Department> GetDepartments()
        //{
        //    return context.Departments;

        //}

        [HttpGet]
        [EnableQuery(PageSize = 25, EnsureStableOrdering = false)]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await departmentService.GetDepartmentEmployees();

        }

        [HttpGet("searchbyId")]
        public async Task<IActionResult> GetDepartments(string Id)
        {            
            return Ok(await departmentService.GetDepartmentEmployees(Id));
        } 

        [HttpGet("search")]
        public IActionResult GetDepartments(string location, string deptName)
        {
            var loc = location ?? string.Empty;
            var dept = deptName ?? string.Empty;
            
           
            return Ok(departmentService.GetDepartmentEmployees(deptName, location));

            //if (deptName == null && location != null)
            //{
                
            //    //return Ok(await context.Departments.AsNoTracking().Where(d =>                  
            //    //   d.Location.Contains(loc)).Include("Employees").Select(x => new {
            //    //       DepartmentName = x.DeptName,
            //    //       Location = x.Location,
            //    //       Employees = x.Employees.Where(e => e.DepartmentId == x.Id).Select(ex => new { EmployeeName = ex.EmpName, Designation = ex.Designation })
            //    //   }).ToListAsync());            
            //}
            //else if (location == null && deptName != null)
            //{
            //    return Ok(await context.Departments.AsNoTracking().Where(d =>
            //       d.DeptName.Contains(dept)).Include("Employees").Select(x => new {
            //           DepartmentName = x.DeptName,
            //           Location = x.Location,
            //           Employees = x.Employees.Where(e => e.DepartmentId == x.Id).Select(ex => new { EmployeeName = ex.EmpName, Designation = ex.Designation })
            //       }).ToListAsync());
            //}

            //else if (deptName == null && location == null)
            //{
            //    return Ok(await context.Departments.AsNoTracking().Include("Employees").Select(x => new {
            //        DepartmentName = x.DeptName,
            //        Location = x.Location,
            //        Employees = x.Employees.Where(e => e.DepartmentId == x.Id).Select(ex => new { EmployeeName = ex.EmpName, Designation = ex.Designation })
            //    }).ToListAsync());
            //}
            //else
            //{
            //    return Ok(await context.Departments.AsNoTracking().Where(d =>
            //       d.Location.Contains(loc.ToLower()) && d.DeptName.Contains(dept.ToLower())).Include("Employees").Select(x => new { DepartmentName = x.DeptName, Location = x.Location, 
            //           Employees = x.Employees.Where(e => e.DepartmentId ==x.Id).Select(ex => new { EmployeeName = ex.EmpName, Designation = ex.Designation })
            //       }).ToListAsync());
            //}

        }
    }
}
