using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Travelers.CSS.ApprovalFlow.Migrations
{
    public partial class RuleHistoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RuleHistoryName",
                table: "RuleHistorys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RuleHistoryName",
                table: "RuleHistorys");
        }
    }
}
