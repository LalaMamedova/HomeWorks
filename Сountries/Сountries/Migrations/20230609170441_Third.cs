using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Сountries.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryRuler",
                table: "Countrys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Himn",
                table: "Countrys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryRuler",
                table: "Countrys");

            migrationBuilder.DropColumn(
                name: "Himn",
                table: "Countrys");
        }
    }
}
