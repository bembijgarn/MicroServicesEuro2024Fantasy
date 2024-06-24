using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EURO2024Stat.DATA.Migrations
{
    /// <inheritdoc />
    public partial class player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TshirtNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    FantasyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Age", "CountryID", "FantasyPrice", "Name", "Position", "TshirtNumber" },
                values: new object[,]
                {
                    { 1, 23, 1, 100m, "Khvicha Kvaratskhelia", "Forward", 7 },
                    { 2, 24, 1, 100m, "Giorgi Mamardashvili", "GoalKeeper", 25 },
                    { 3, 24, 1, 100m, "Giorgi Mikautadze", "Forward", 22 },
                    { 4, 25, 1, 100m, "Giorgi Qochorashvili", "MidFielder", 6 },
                    { 5, 34, 1, 100m, "Guram Kashia", "Defender", 4 },
                    { 6, 21, 2, 100m, "Musiala", "Forward", 14 },
                    { 7, 36, 2, 100m, "Toni Kroos", "MidFielder", 8 },
                    { 8, 28, 2, 100m, "Joshua Kimmich", "MidFielder", 6 },
                    { 9, 35, 2, 100m, "Manuel Neuer", "GoalKeeper", 1 },
                    { 10, 33, 2, 100m, "Mats Hummels", "Defender", 5 },
                    { 11, 30, 3, 7m, "Xherdan Shaqiri", "Forward", 23 },
                    { 12, 33, 3, 11m, "Yann Sommer", "GoalKeeper", 1 },
                    { 13, 30, 3, 22m, "Granit Xhaka", "MidFielder", 10 },
                    { 14, 29, 3, 12m, "Ricardo Rodriguez", "Defender", 13 },
                    { 15, 25, 3, 12m, "Breel Embolo", "Forward", 7 },
                    { 16, 28, 4, 12m, "Andrew Robertson", "Defender", 3 },
                    { 17, 25, 4, 6m, "Scott McTominay", "MidFielder", 6 },
                    { 18, 26, 4, 11m, "John McGinn", "MidFielder", 7 },
                    { 19, 25, 4, 22m, "Che Adams", "Forward", 9 },
                    { 20, 37, 4, 12m, "David Marshall", "GoalKeeper", 1 },
                    { 21, 21, 5, 20m, "Dominik Szoboszlai", "MidFielder", 10 },
                    { 22, 28, 5, 16m, "Willi Orban", "Defender", 6 },
                    { 23, 31, 5, 22m, "Peter Gulacsi", "GoalKeeper", 1 },
                    { 24, 33, 5, 11m, "Adam Szalai", "Forward", 9 },
                    { 25, 25, 5, 16m, "Roland Sallai", "Forward", 18 },
                    { 26, 33, 6, 100m, "Sergio Busquets", "MidFielder", 5 },
                    { 27, 29, 6, 100m, "Gerard Moreno", "Forward", 7 },
                    { 28, 32, 6, 100m, "Jordi Alba", "Defender", 18 },
                    { 29, 30, 6, 100m, "David de Gea", "GoalKeeper", 1 },
                    { 30, 30, 6, 100m, "Thiago Alcantara", "MidFielder", 8 },
                    { 31, 22, 7, 100m, "Gianluigi Donnarumma", "GoalKeeper", 21 },
                    { 32, 34, 7, 100m, "Leonardo Bonucci", "Defender", 19 },
                    { 33, 30, 7, 100m, "Jorginho", "MidFielder", 8 },
                    { 34, 31, 7, 100m, "Ciro Immobile", "Forward", 17 },
                    { 35, 30, 7, 100m, "Lorenzo Insigne", "Forward", 10 },
                    { 36, 32, 8, 4m, "Etrit Berisha", "GoalKeeper", 1 },
                    { 37, 27, 8, 5m, "Elseid Hysaj", "Defender", 23 },
                    { 38, 30, 8, 12m, "Odise Roshi", "Forward", 11 },
                    { 39, 24, 8, 5m, "Keidi Bare", "MidFielder", 18 },
                    { 40, 31, 8, 5m, "Sokol Cikalleshi", "Forward", 7 },
                    { 41, 35, 9, 100m, "Luka Modric", "MidFielder", 10 },
                    { 42, 32, 9, 33m, "Ivan Perisic", "Forward", 4 },
                    { 43, 32, 9, 22m, "Domagoj Vida", "Defender", 21 },
                    { 44, 27, 9, 11m, "Mateo Kovacic", "MidFielder", 8 },
                    { 45, 20, 9, 22m, "Josko Gvardiol", "Defender", 14 },
                    { 46, 28, 10, 100m, "Harry Kane", "Forward", 9 },
                    { 47, 28, 10, 100m, "Jordan Pickford", "GoalKeeper", 1 },
                    { 48, 28, 10, 78m, "Raheem Sterling", "Forward", 10 },
                    { 49, 23, 10, 20m, "Declan Rice", "MidFielder", 4 },
                    { 50, 29, 10, 30m, "Harry Maguire", "Defender", 6 },
                    { 51, 30, 11, 75m, "Christian Eriksen", "MidFielder", 10 },
                    { 52, 35, 11, 23m, "Kasper Schmeichel", "GoalKeeper", 1 },
                    { 53, 25, 11, 60m, "Andreas Christensen", "Defender", 6 },
                    { 54, 27, 11, 12m, "Yussuf Poulsen", "Forward", 20 },
                    { 55, 25, 11, 33m, "Pierre-Emile Hojbjerg", "MidFielder", 5 },
                    { 56, 29, 12, 10m, "Jan Oblak", "GoalKeeper", 1 },
                    { 57, 33, 12, 12m, "Josip Ilicic", "Forward", 9 },
                    { 58, 27, 12, 33m, "Benjamin Verbic", "MidFielder", 7 },
                    { 59, 31, 12, 22m, "Miha Mevlja", "Defender", 6 },
                    { 60, 29, 12, 12m, "Haris Vuckic", "MidFielder", 11 },
                    { 61, 33, 13, 28m, "Nemanja Matic", "MidFielder", 21 },
                    { 62, 32, 13, 30m, "Dusan Tadic", "Forward", 10 },
                    { 63, 27, 13, 65m, "Aleksandar Mitrovic", "Forward", 9 },
                    { 64, 32, 13, 22m, "Stefan Mitrovic", "Defender", 13 },
                    { 65, 27, 13, 33m, "Sergej Milinkovic-Savic", "MidFielder", 20 },
                    { 66, 28, 14, 80m, "Memphis Depay", "Forward", 10 },
                    { 67, 30, 14, 35m, "Georginio Wijnaldum", "MidFielder", 8 },
                    { 68, 23, 14, 78m, "Matthijs de Ligt", "Defender", 3 },
                    { 69, 25, 14, 50m, "Denzel Dumfries", "Defender", 22 },
                    { 70, 25, 14, 100m, "Frenkie de Jong", "MidFielder", 21 },
                    { 71, 23, 15, 200m, "Kylian Mbappe", "Forward", 10 },
                    { 72, 30, 15, 100m, "Antoine Griezmann", "Forward", 7 },
                    { 73, 30, 15, 60m, "Paul Pogba", "MidFielder", 6 },
                    { 74, 28, 15, 100m, "Raphael Varane", "Defender", 4 },
                    { 75, 35, 15, 100m, "Hugo Lloris", "GoalKeeper", 1 },
                    { 76, 29, 16, 100m, "David Alaba", "Defender", 8 },
                    { 77, 32, 16, 70m, "Marko Arnautovic", "Forward", 7 },
                    { 78, 27, 16, 23m, "Marcel Sabitzer", "MidFielder", 9 },
                    { 79, 29, 16, 11m, "Stefan Lainer", "Defender", 22 },
                    { 80, 24, 16, 22m, "Konrad Laimer", "MidFielder", 14 },
                    { 81, 32, 17, 80m, "Robert Lewandowski", "Forward", 9 },
                    { 82, 31, 17, 22m, "Wojciech Szczesny", "GoalKeeper", 1 },
                    { 83, 28, 17, 33m, "Arkadiusz Milik", "Forward", 7 },
                    { 84, 33, 17, 11m, "Kamil Glik", "Defender", 15 },
                    { 85, 27, 17, 25m, "Piotr Zielinski", "MidFielder", 19 },
                    { 86, 23, 18, 12m, "Ianis Hagi", "MidFielder", 10 },
                    { 87, 28, 18, 7m, "Florin Andone", "Forward", 11 },
                    { 88, 34, 18, 8m, "Ciprian Tatarusanu", "GoalKeeper", 1 },
                    { 89, 32, 18, 11m, "Vlad Chiriches", "Defender", 3 },
                    { 90, 26, 18, 22m, "Alexandru Mitrita", "Forward", 20 },
                    { 91, 30, 19, 100m, "Kevin De Bruyne", "MidFielder", 7 },
                    { 92, 28, 19, 100m, "Romelu Lukaku", "Forward", 9 },
                    { 93, 31, 19, 100m, "Thibaut Courtois", "GoalKeeper", 1 },
                    { 94, 33, 19, 44m, "Toby Alderweireld", "Defender", 2 },
                    { 95, 25, 19, 35m, "Youri Tielemans", "MidFielder", 8 },
                    { 96, 27, 20, 22m, "Milan Skriniar", "Defender", 14 },
                    { 97, 32, 20, 12m, "Martin Dubravka", "GoalKeeper", 1 },
                    { 98, 34, 20, 66m, "Juraj Kucka", "MidFielder", 19 },
                    { 99, 30, 20, 34m, "Robert Mak", "MidFielder", 20 },
                    { 100, 26, 20, 17m, "Ondrej Duda", "Forward", 22 },
                    { 101, 32, 21, 40m, "Andriy Yarmolenko", "Forward", 7 },
                    { 102, 25, 21, 60m, "Oleksandr Zinchenko", "MidFielder", 17 },
                    { 103, 25, 21, 34m, "Mykola Matviyenko", "Defender", 22 },
                    { 104, 37, 21, 100m, "Andriy Pyatov", "GoalKeeper", 12 },
                    { 105, 26, 21, 30m, "Roman Yaremchuk", "Forward", 9 },
                    { 106, 39, 22, 100m, "Cristiano Ronaldo", "Forward", 7 },
                    { 107, 29, 22, 100m, "Bruno Fernandes", "MidFielder", 8 },
                    { 108, 26, 22, 100m, "Ruben Dias", "Defender", 3 },
                    { 109, 36, 22, 50m, "Rui Patricio", "GoalKeeper", 1 },
                    { 110, 23, 22, 70m, "Joao Felix", "Forward", 21 },
                    { 111, 36, 23, 11m, "Burak Yilmaz", "Forward", 17 },
                    { 112, 28, 23, 70m, "Hakan Calhanoglu", "MidFielder", 10 },
                    { 113, 24, 23, 20m, "Merih Demiral", "Defender", 3 },
                    { 114, 26, 23, 20m, "Ugurcan Cakir", "GoalKeeper", 23 },
                    { 115, 24, 23, 22m, "Cengiz Under", "Forward", 17 },
                    { 116, 27, 24, 5m, "Tomas Soucek", "MidFielder", 15 },
                    { 117, 26, 24, 8m, "Patrik Schick", "Forward", 10 },
                    { 118, 32, 24, 10m, "Tomas Vaclik", "GoalKeeper", 1 },
                    { 119, 29, 24, 8m, "Vladimir Coufal", "Defender", 5 },
                    { 120, 27, 24, 10m, "Antonin Barak", "MidFielder", 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
