using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Travelers.CSS.ApprovalFlow.Migrations
{
    public partial class EmployeeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "ApprovalRules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "ApprovalRules");
        }
    }
}
