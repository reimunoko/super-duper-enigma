using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeService.Data.Migrations
{
    public partial class logTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

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
    }
}
