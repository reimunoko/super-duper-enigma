using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeService.Data.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName", "Location" },
                values: new object[] { 1, "HR", "StarCity" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName", "Location" },
                values: new object[] { 2, "Finance", "CentralCity" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptName", "Location" },
                values: new object[] { 3, "IT", "Gotham" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Designation", "EmpName", "Salary" },
                values: new object[] { 1, 1, "HR", "John", 1000000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Designation", "EmpName", "Salary" },
                values: new object[] { 2, 2, "Finance Manager", "James", 1000000 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Designation", "EmpName", "Salary" },
                values: new object[] { 3, 3, "Engineer", "Jonathan", 1000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
