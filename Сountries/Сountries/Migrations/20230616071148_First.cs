using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Сountries.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernmentForm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadOfStatePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOfStatePositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadOfStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOfStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadOfStates_HeadOfStatePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "HeadOfStatePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Himn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRulerId = table.Column<int>(type: "int", nullable: false),
                    GovermentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countrys_Governments_GovermentTypeId",
                        column: x => x.GovermentTypeId,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countrys_HeadOfStates_CountryRulerId",
                        column: x => x.CountryRulerId,
                        principalTable: "HeadOfStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfStates_PositionId",
                table: "HeadOfStates",
                column: "PositionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countrys");

            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropTable(
                name: "HeadOfStates");

            migrationBuilder.DropTable(
                name: "HeadOfStatePositions");
        }
    }
}
