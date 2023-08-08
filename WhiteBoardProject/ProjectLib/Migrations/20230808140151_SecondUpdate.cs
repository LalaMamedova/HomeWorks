using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectLib.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArts_Users_UserId",
                table: "UserArts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserArts_UserArtId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserArtId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserArtId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserArts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserArts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserArts_UserId1",
                table: "UserArts",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArts_Users_UserId",
                table: "UserArts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserArts_Users_UserId1",
                table: "UserArts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArts_Users_UserId",
                table: "UserArts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserArts_Users_UserId1",
                table: "UserArts");

            migrationBuilder.DropIndex(
                name: "IX_UserArts_UserId1",
                table: "UserArts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserArts");

            migrationBuilder.AddColumn<int>(
                name: "UserArtId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserArts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserArtId",
                table: "Users",
                column: "UserArtId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArts_Users_UserId",
                table: "UserArts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserArts_UserArtId",
                table: "Users",
                column: "UserArtId",
                principalTable: "UserArts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
