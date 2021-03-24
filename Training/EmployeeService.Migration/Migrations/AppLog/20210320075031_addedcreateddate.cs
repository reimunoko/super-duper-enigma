using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeService.EFMigration.Migrations.AppLog
{
    public partial class addedcreateddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Log",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Log");
        }
    }
}
