using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Сountries.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeadOfStates_PositionId",
                table: "HeadOfStates");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_CountryRulerId",
                table: "Countrys");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_GovermentTypeId",
                table: "Countrys");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfStates_PositionId",
                table: "HeadOfStates",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_CountryRulerId",
                table: "Countrys",
                column: "CountryRulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_GovermentTypeId",
                table: "Countrys",
                column: "GovermentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeadOfStates_PositionId",
                table: "HeadOfStates");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_CountryRulerId",
                table: "Countrys");

            migrationBuilder.DropIndex(
                name: "IX_Countrys_GovermentTypeId",
                table: "Countrys");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfStates_PositionId",
                table: "HeadOfStates",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_CountryRulerId",
                table: "Countrys",
                column: "CountryRulerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countrys_GovermentTypeId",
                table: "Countrys",
                column: "GovermentTypeId",
                unique: true);
        }
    }
}
