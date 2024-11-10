using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssigneeId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AssigneeId",
                table: "Tasks",
                column: "AssigneeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AssigneeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "Tasks");
        }
    }
}
