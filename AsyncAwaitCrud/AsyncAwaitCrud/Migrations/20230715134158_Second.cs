using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncAwaitCrud.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "smallmoney",
                table: "Flowers",
                newName: "Price");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Flowers",
                type: "smallmoney",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flowers",
                newName: "smallmoney");

            migrationBuilder.AlterColumn<float>(
                name: "smallmoney",
                table: "Flowers",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "smallmoney");
        }
    }
}
