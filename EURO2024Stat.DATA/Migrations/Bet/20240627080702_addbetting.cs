using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EURO2024Stat.DATA.Migrations.Bet
{
    /// <inheritdoc />
    public partial class addbetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetMatches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    HomeCountryId = table.Column<int>(type: "int", nullable: false),
                    HomeCountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayCountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayCountryId = table.Column<int>(type: "int", nullable: false),
                    HomeCoefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrawCoefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AwayCoefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetMatches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BetStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "BetMatches",
                columns: new[] { "ID", "AwayCoefficient", "AwayCountryId", "AwayCountryName", "DrawCoefficient", "HomeCoefficient", "HomeCountryId", "HomeCountryName", "MatchId", "isFinished" },
                values: new object[,]
                {
                    { 1, 5.6m, 4, "Scotland", 3.4m, 1.4m, 2, "Germany", 1, false },
                    { 2, 3.2m, 5, "Hungary", 3.5m, 1.7m, 3, "Switzerland", 2, false },
                    { 3, 8.0m, 5, "Hungary", 3.0m, 1.6m, 2, "Germany", 3, false },
                    { 4, 1.95m, 3, "Switzerland", 3.7m, 3.0m, 4, "Scotnald", 4, false },
                    { 5, 3.5m, 3, "Switzerland", 3.4m, 1.5m, 2, "Germany", 5, false },
                    { 6, 2.95m, 5, "Hungary", 3.7m, 1.85m, 4, "Scotland", 6, false },
                    { 7, 5.6m, 9, "Croatia", 3.4m, 1.4m, 6, "Spain", 7, false },
                    { 8, 3.2m, 8, "Albania", 3.5m, 1.7m, 7, "Italy", 8, false },
                    { 9, 8.0m, 8, "Albania", 3.0m, 1.6m, 6, "Spain", 9, false },
                    { 10, 1.95m, 7, "Italy", 3.7m, 3.0m, 9, "Croatia", 10, false },
                    { 11, 3.5m, 7, "Italy", 3.4m, 1.5m, 6, "Spain", 11, false },
                    { 12, 2.95m, 8, "Albania", 3.7m, 1.85m, 9, "Croatia", 12, false },
                    { 13, 5.6m, 12, "Slovenia", 3.4m, 1.4m, 10, "England", 13, false },
                    { 14, 3.2m, 13, "Serbia", 3.5m, 1.7m, 11, "Denmark", 14, false },
                    { 15, 8.0m, 13, "Serbia", 3.0m, 1.6m, 10, "England", 15, false },
                    { 16, 1.95m, 11, "Denmark", 3.7m, 3.0m, 12, "Slovenia", 16, false },
                    { 17, 3.5m, 11, "Denmark", 3.4m, 1.5m, 10, "England", 17, false },
                    { 18, 2.95m, 13, "Serbia", 3.7m, 1.85m, 12, "Slovenia", 18, false },
                    { 19, 5.6m, 17, "Poland", 3.4m, 1.4m, 14, "Netherlands", 19, false },
                    { 20, 3.2m, 16, "Austria", 3.5m, 1.7m, 15, "France", 20, false },
                    { 21, 8.0m, 16, "Austria", 3.0m, 1.6m, 14, "Netherlands", 21, false },
                    { 22, 1.95m, 15, "France", 3.7m, 3.0m, 17, "Poland", 22, false },
                    { 23, 3.5m, 15, "France", 3.4m, 1.5m, 14, "Netherlands", 23, false },
                    { 24, 2.95m, 16, "Austria", 3.7m, 1.85m, 17, "Poland", 24, false },
                    { 25, 5.6m, 21, "Ukraine", 3.4m, 1.4m, 18, "Romania", 25, false },
                    { 26, 3.2m, 20, "Slovakia", 3.5m, 1.7m, 19, "Belgium", 26, false },
                    { 27, 8.0m, 20, "Slovakia", 3.0m, 1.6m, 18, "Romania", 27, false },
                    { 28, 1.95m, 19, "Belgium", 3.7m, 3.0m, 21, "Ukraine", 28, false },
                    { 29, 3.5m, 19, "Belgium", 3.4m, 1.5m, 18, "Romania", 29, false },
                    { 30, 2.95m, 20, "Slovakia", 3.7m, 1.85m, 21, "Ukraine", 30, false },
                    { 31, 5.6m, 23, "Turkey", 3.4m, 1.4m, 22, "Portugal", 31, false },
                    { 32, 3.2m, 24, "Czech Republic", 3.5m, 1.7m, 1, "Georgia", 32, false },
                    { 33, 8.0m, 24, "Czech Republic", 3.0m, 1.6m, 22, "Portugal", 33, false },
                    { 34, 1.95m, 1, "Georgia", 3.7m, 3.0m, 23, "Turkey", 34, false },
                    { 35, 3.5m, 1, "Georgia", 3.4m, 1.5m, 22, "Portugal", 35, false },
                    { 36, 2.95m, 24, "Czech Republic", 3.7m, 1.85m, 23, "Turkey", 36, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetMatches");

            migrationBuilder.DropTable(
                name: "Bets");
        }
    }
}
