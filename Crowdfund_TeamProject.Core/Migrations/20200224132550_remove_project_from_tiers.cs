using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund_TeamProject.Migrations
{
    public partial class remove_project_from_tiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "Project",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpirationDate",
                table: "Project",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
