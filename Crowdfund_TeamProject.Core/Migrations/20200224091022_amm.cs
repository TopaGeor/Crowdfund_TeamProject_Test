using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund_TeamProject.Migrations
{
    public partial class amm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Achieved",
                table: "Project",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achieved",
                table: "Project");
        }
    }
}
