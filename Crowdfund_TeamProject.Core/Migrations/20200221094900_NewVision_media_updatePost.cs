using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crowdfund_TeamProject.Migrations
{
    public partial class NewVision_media_updatePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UpdatePost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Post = table.Column<string>(nullable: true),
                    DatePost = table.Column<DateTimeOffset>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdatePost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpdatePost_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpdatePost_ProjectId",
                table: "UpdatePost",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpdatePost");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Project");
        }
    }
}
