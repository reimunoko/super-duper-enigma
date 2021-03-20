using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Data.Configuration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //builder.HasData(new Department { Id = 1, DeptName = "HR", Location="StarCity" });
            //builder.HasData(new Department { Id = 2, DeptName = "Finance", Location = "CentralCity" });
            //builder.HasData(new Department { Id = 3, DeptName = "IT", Location = "Gotham" });

         


        }
    }
}
