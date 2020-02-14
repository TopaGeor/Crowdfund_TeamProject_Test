using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund_TeamProject.Migrations
{
    public partial class Backer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backer_Project_ProjectId",
                table: "Backer");

            migrationBuilder.DropIndex(
                name: "IX_Backer_ProjectId",
                table: "Backer");

            migrationBuilder.DropColumn(
                name: "FundAmount",
                table: "Backer");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Backer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Backer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Backer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectBacker",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    BackerId = table.Column<int>(nullable: false)
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
                name: "IX_Backer_Email",
                table: "Backer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Backer_Name",
                table: "Backer",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBacker_ProjectId",
                table: "ProjectBacker",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBacker");

            migrationBuilder.DropIndex(
                name: "IX_Backer_Email",
                table: "Backer");

            migrationBuilder.DropIndex(
                name: "IX_Backer_Name",
                table: "Backer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Backer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Backer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FundAmount",
                table: "Backer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Backer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Backer_ProjectId",
                table: "Backer",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Backer_Project_ProjectId",
                table: "Backer",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
