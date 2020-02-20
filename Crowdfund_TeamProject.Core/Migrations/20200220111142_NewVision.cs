using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund_TeamProject.Migrations
{
    public partial class NewVision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBacker");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Creator");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Backer");

            migrationBuilder.AddColumn<int>(
                name: "BackerId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExplirationDate",
                table: "Project",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Project_BackerId",
                table: "Project",
                column: "BackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Backer_BackerId",
                table: "Project",
                column: "BackerId",
                principalTable: "Backer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Backer_BackerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_BackerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BackerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ExplirationDate",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Creator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Backer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectBacker",
                columns: table => new
                {
                    BackerId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBacker", x => new { x.BackerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectBacker_Backer_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectBacker_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBacker_ProjectId",
                table: "ProjectBacker",
                column: "ProjectId");
        }
    }
}
