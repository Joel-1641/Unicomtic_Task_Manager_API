using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class tasklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_userId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Address_userId",
                table: "Address",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_userId",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_userId",
                table: "Address",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
