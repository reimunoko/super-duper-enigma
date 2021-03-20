using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Data
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasData(new Employee { Id = 1, EmpName = "John", Designation= "HR", Salary=1000000, DepartmentId=1 });
            //builder.HasData(new Employee { Id = 2, EmpName = "James", Designation = "Finance Manager", Salary = 1000000, DepartmentId =2 });
            //builder.HasData(new Employee { Id = 3, EmpName = "Jonathan", Designation = "Engineer", Salary = 1000000, DepartmentId =3 });

            builder.HasOne(o => o.Department).WithMany(m => m.Employees);
        }
    }
}
