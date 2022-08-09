using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTree.Migrations
{
    public partial class newMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "ProjectTasks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "ProjectTasks");
        }
    }
}
