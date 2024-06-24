using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EURO2024Stat.DATA.Migrations.Match
{
    /// <inheritdoc />
    public partial class matchresulttbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeCountryID = table.Column<int>(type: "int", nullable: false),
                    AwayCountryID = table.Column<int>(type: "int", nullable: false),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchID = table.Column<int>(type: "int", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchResults_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "ID", "AwayCountryID", "Group", "HomeCountryID", "IsFinished", "MatchDatetime", "Stadium" },
                values: new object[,]
                {
                    { 1, 4, "A", 2, false, new DateTime(2024, 6, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), "Allianz Arena, Munich" },
                    { 2, 5, "A", 3, false, new DateTime(2024, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Olympiastadion, Berlin" },
                    { 3, 5, "A", 2, false, new DateTime(2024, 6, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), "Allianz Arena, Munich" },
                    { 4, 3, "A", 4, false, new DateTime(2024, 6, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 5, 3, "A", 2, false, new DateTime(2024, 6, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), "Volksparkstadion, Hamburg" },
                    { 6, 5, "A", 4, false, new DateTime(2024, 6, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Olympiastadion, Berlin" },
                    { 7, 9, "B", 6, false, new DateTime(2024, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 8, 8, "B", 7, false, new DateTime(2024, 6, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), "RheinEnergieStadion, Cologne" },
                    { 9, 8, "B", 6, false, new DateTime(2024, 6, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "Olympiastadion, Berlin" },
                    { 10, 7, "B", 9, false, new DateTime(2024, 6, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "Allianz Arena, Munich" },
                    { 11, 7, "B", 6, false, new DateTime(2024, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "Volksparkstadion, Hamburg" },
                    { 12, 8, "B", 9, false, new DateTime(2024, 6, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 13, 12, "C", 10, false, new DateTime(2024, 6, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), "Veltins-Arena, Gelsenkirchen" },
                    { 14, 13, "C", 11, false, new DateTime(2024, 6, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), "Volksparkstadion, Hamburg" },
                    { 15, 13, "C", 10, false, new DateTime(2024, 6, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), "Commerzbank-Arena, Frankfurt" },
                    { 16, 11, "C", 12, false, new DateTime(2024, 6, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), "Volksparkstadion, Hamburg" },
                    { 17, 11, "C", 10, false, new DateTime(2024, 6, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), "Veltins-Arena, Gelsenkirchen" },
                    { 18, 13, "C", 12, false, new DateTime(2024, 6, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), "Commerzbank-Arena, Frankfurt" },
                    { 19, 17, "D", 14, false, new DateTime(2024, 6, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull Arena, Leipzig" },
                    { 20, 16, "D", 15, false, new DateTime(2024, 6, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), "Esprit Arena, Düsseldorf" },
                    { 21, 16, "D", 14, false, new DateTime(2024, 6, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull Arena, Leipzig" },
                    { 22, 15, "D", 17, false, new DateTime(2024, 6, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), "Esprit Arena, Düsseldorf" },
                    { 23, 15, "D", 14, false, new DateTime(2024, 6, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), "Commerzbank-Arena, Frankfurt" },
                    { 24, 16, "D", 17, false, new DateTime(2024, 6, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull Arena, Leipzig" },
                    { 25, 21, "E", 18, false, new DateTime(2024, 6, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 26, 20, "E", 19, false, new DateTime(2024, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), "Commerzbank-Arena, Frankfurt" },
                    { 27, 20, "E", 18, false, new DateTime(2024, 6, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull Arena, Leipzig" },
                    { 28, 19, "E", 21, false, new DateTime(2024, 6, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "Olympiastadion, Berlin" },
                    { 29, 19, "E", 18, false, new DateTime(2024, 6, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), "Esprit Arena, Düsseldorf" },
                    { 30, 20, "E", 21, false, new DateTime(2024, 6, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 31, 23, "F", 22, false, new DateTime(2024, 6, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), "RheinEnergieStadion, Cologne" },
                    { 32, 24, "F", 1, false, new DateTime(2024, 6, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), "Red Bull Arena, Leipzig" },
                    { 33, 24, "F", 22, false, new DateTime(2024, 6, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz Arena, Stuttgart" },
                    { 34, 1, "F", 23, false, new DateTime(2024, 6, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "Allianz Arena, Munich" },
                    { 35, 1, "F", 22, false, new DateTime(2024, 6, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), "Volksparkstadion, Hamburg" },
                    { 36, 24, "F", 23, false, new DateTime(2024, 6, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), "Olympiastadion, Berlin" }
                });

            migrationBuilder.InsertData(
                table: "MatchResults",
                columns: new[] { "ID", "AwayScore", "HomeScore", "MatchID" },
                values: new object[,]
                {
                    { 1, 0, 0, 1 },
                    { 2, 0, 0, 2 },
                    { 3, 0, 0, 3 },
                    { 4, 0, 0, 4 },
                    { 5, 0, 0, 5 },
                    { 6, 0, 0, 6 },
                    { 7, 0, 0, 7 },
                    { 8, 0, 0, 8 },
                    { 9, 0, 0, 9 },
                    { 10, 0, 0, 10 },
                    { 11, 0, 0, 11 },
                    { 12, 0, 0, 12 },
                    { 13, 0, 0, 13 },
                    { 14, 0, 0, 14 },
                    { 15, 0, 0, 15 },
                    { 16, 0, 0, 16 },
                    { 17, 0, 0, 17 },
                    { 18, 0, 0, 18 },
                    { 19, 0, 0, 19 },
                    { 20, 0, 0, 20 },
                    { 21, 0, 0, 21 },
                    { 22, 0, 0, 22 },
                    { 23, 0, 0, 23 },
                    { 24, 0, 0, 24 },
                    { 25, 0, 0, 25 },
                    { 26, 0, 0, 26 },
                    { 27, 0, 0, 27 },
                    { 28, 0, 0, 28 },
                    { 29, 0, 0, 29 },
                    { 30, 0, 0, 30 },
                    { 31, 0, 0, 31 },
                    { 32, 0, 0, 32 },
                    { 33, 0, 0, 33 },
                    { 34, 0, 0, 34 },
                    { 35, 0, 0, 35 },
                    { 36, 0, 0, 36 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchID",
                table: "MatchResults",
                column: "MatchID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
