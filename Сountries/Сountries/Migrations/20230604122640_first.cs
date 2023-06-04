using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Сountries.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MapImgLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<float>(type: "real", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    GDP = table.Column<double>(type: "float", nullable: false),
                    GovermentType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GovernmentForm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Governments_Countrys_Id",
                        column: x => x.Id,
                        principalTable: "Countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropTable(
                name: "Countrys");
        }
    }
}
