using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
    // Players for Georgia (ID: 1)
    new Player { ID = 1, Name = "Khvicha Kvaratskhelia", Position = "Forward", TshirtNumber = 7, Age = 23, CountryID = 1, FantasyPrice = 100 },
    new Player { ID = 2, Name = "Giorgi Mamardashvili", Position = "GoalKeeper", TshirtNumber = 25, Age = 24, CountryID = 1, FantasyPrice = 100 },
    new Player { ID = 3, Name = "Giorgi Mikautadze", Position = "Forward", TshirtNumber = 22, Age = 24, CountryID = 1, FantasyPrice = 100 },
    new Player { ID = 4, Name = "Giorgi Qochorashvili", Position = "MidFielder", TshirtNumber = 6, Age = 25, CountryID = 1, FantasyPrice = 100 },
    new Player { ID = 5, Name = "Guram Kashia", Position = "Defender", TshirtNumber = 4, Age = 34, CountryID = 1, FantasyPrice = 100 },

    // Players for Germany (ID: 2)
    new Player { ID = 6, Name = "Musiala", Position = "Forward", TshirtNumber = 14, Age = 21, CountryID = 2, FantasyPrice = 100 },
    new Player { ID = 7, Name = "Toni Kroos", Position = "MidFielder", TshirtNumber = 8, Age = 36, CountryID = 2, FantasyPrice = 100 },
    new Player { ID = 8, Name = "Joshua Kimmich", Position = "MidFielder", TshirtNumber = 6, Age = 28, CountryID = 2, FantasyPrice = 100 },
    new Player { ID = 9, Name = "Manuel Neuer", Position = "GoalKeeper", TshirtNumber = 1, Age = 35, CountryID = 2, FantasyPrice = 100 },
    new Player { ID = 10, Name = "Mats Hummels", Position = "Defender", TshirtNumber = 5, Age = 33, CountryID = 2, FantasyPrice = 100 },

    // Players for Switzerland (ID: 3)
    new Player { ID = 11, Name = "Xherdan Shaqiri", Position = "Forward", TshirtNumber = 23, Age = 30, CountryID = 3, FantasyPrice = 7 },
    new Player { ID = 12, Name = "Yann Sommer", Position = "GoalKeeper", TshirtNumber = 1, Age = 33, CountryID = 3, FantasyPrice = 11 },
    new Player { ID = 13, Name = "Granit Xhaka", Position = "MidFielder", TshirtNumber = 10, Age = 30, CountryID = 3, FantasyPrice = 22 },
    new Player { ID = 14, Name = "Ricardo Rodriguez", Position = "Defender", TshirtNumber = 13, Age = 29, CountryID = 3, FantasyPrice = 12 },
    new Player { ID = 15, Name = "Breel Embolo", Position = "Forward", TshirtNumber = 7, Age = 25, CountryID = 3, FantasyPrice = 12 },

    // Players for Scotland (ID: 4)
    new Player { ID = 16, Name = "Andrew Robertson", Position = "Defender", TshirtNumber = 3, Age = 28, CountryID = 4, FantasyPrice = 12 },
    new Player { ID = 17, Name = "Scott McTominay", Position = "MidFielder", TshirtNumber = 6, Age = 25, CountryID = 4, FantasyPrice = 6 },
    new Player { ID = 18, Name = "John McGinn", Position = "MidFielder", TshirtNumber = 7, Age = 26, CountryID = 4, FantasyPrice = 11 },
    new Player { ID = 19, Name = "Che Adams", Position = "Forward", TshirtNumber = 9, Age = 25, CountryID = 4, FantasyPrice = 22 },
    new Player { ID = 20, Name = "David Marshall", Position = "GoalKeeper", TshirtNumber = 1, Age = 37, CountryID = 4, FantasyPrice = 12 },

    // Players for Hungary (ID: 5)
    new Player { ID = 21, Name = "Dominik Szoboszlai", Position = "MidFielder", TshirtNumber = 10, Age = 21, CountryID = 5, FantasyPrice = 20 },
    new Player { ID = 22, Name = "Willi Orban", Position = "Defender", TshirtNumber = 6, Age = 28, CountryID = 5, FantasyPrice = 16 },
    new Player { ID = 23, Name = "Peter Gulacsi", Position = "GoalKeeper", TshirtNumber = 1, Age = 31, CountryID = 5, FantasyPrice = 22 },
    new Player { ID = 24, Name = "Adam Szalai", Position = "Forward", TshirtNumber = 9, Age = 33, CountryID = 5, FantasyPrice = 11 },
    new Player { ID = 25, Name = "Roland Sallai", Position = "Forward", TshirtNumber = 18, Age = 25, CountryID = 5, FantasyPrice = 16 },

    // Players for Spain (ID: 6)
    new Player { ID = 26, Name = "Sergio Busquets", Position = "MidFielder", TshirtNumber = 5, Age = 33, CountryID = 6, FantasyPrice = 100 },
    new Player { ID = 27, Name = "Gerard Moreno", Position = "Forward", TshirtNumber = 7, Age = 29, CountryID = 6, FantasyPrice = 100 },
    new Player { ID = 28, Name = "Jordi Alba", Position = "Defender", TshirtNumber = 18, Age = 32, CountryID = 6, FantasyPrice = 100 },
    new Player { ID = 29, Name = "David de Gea", Position = "GoalKeeper", TshirtNumber = 1, Age = 30, CountryID = 6, FantasyPrice = 100 },
    new Player { ID = 30, Name = "Thiago Alcantara", Position = "MidFielder", TshirtNumber = 8, Age = 30, CountryID = 6, FantasyPrice = 100 },

    // Players for Italy (ID: 7)
    new Player { ID = 31, Name = "Gianluigi Donnarumma", Position = "GoalKeeper", TshirtNumber = 21, Age = 22, CountryID = 7, FantasyPrice = 100 },
    new Player { ID = 32, Name = "Leonardo Bonucci", Position = "Defender", TshirtNumber = 19, Age = 34, CountryID = 7, FantasyPrice = 100 },
    new Player { ID = 33, Name = "Jorginho", Position = "MidFielder", TshirtNumber = 8, Age = 30, CountryID = 7, FantasyPrice = 100 },
    new Player { ID = 34, Name = "Ciro Immobile", Position = "Forward", TshirtNumber = 17, Age = 31, CountryID = 7, FantasyPrice = 100 },
    new Player { ID = 35, Name = "Lorenzo Insigne", Position = "Forward", TshirtNumber = 10, Age = 30, CountryID = 7, FantasyPrice = 100 },

    // Players for Albania (ID: 8)
    new Player { ID = 36, Name = "Etrit Berisha", Position = "GoalKeeper", TshirtNumber = 1, Age = 32, CountryID = 8, FantasyPrice = 4 },
    new Player { ID = 37, Name = "Elseid Hysaj", Position = "Defender", TshirtNumber = 23, Age = 27, CountryID = 8, FantasyPrice = 5 },
    new Player { ID = 38, Name = "Odise Roshi", Position = "Forward", TshirtNumber = 11, Age = 30, CountryID = 8, FantasyPrice = 12 },
    new Player { ID = 39, Name = "Keidi Bare", Position = "MidFielder", TshirtNumber = 18, Age = 24, CountryID = 8, FantasyPrice = 5 },
    new Player { ID = 40, Name = "Sokol Cikalleshi", Position = "Forward", TshirtNumber = 7, Age = 31, CountryID = 8, FantasyPrice = 5 },

    // Players for Croatia (ID: 9)
    new Player { ID = 41, Name = "Luka Modric", Position = "MidFielder", TshirtNumber = 10, Age = 35, CountryID = 9, FantasyPrice = 100 },
    new Player { ID = 42, Name = "Ivan Perisic", Position = "Forward", TshirtNumber = 4, Age = 32, CountryID = 9, FantasyPrice = 33 },
    new Player { ID = 43, Name = "Domagoj Vida", Position = "Defender", TshirtNumber = 21, Age = 32, CountryID = 9, FantasyPrice = 22 },
    new Player { ID = 44, Name = "Mateo Kovacic", Position = "MidFielder", TshirtNumber = 8, Age = 27, CountryID = 9, FantasyPrice = 11 },
    new Player { ID = 45, Name = "Josko Gvardiol", Position = "Defender", TshirtNumber = 14, Age = 20, CountryID = 9, FantasyPrice = 22 },

    // Players for England (ID: 10)
    new Player { ID = 46, Name = "Harry Kane", Position = "Forward", TshirtNumber = 9, Age = 28, CountryID = 10, FantasyPrice = 100 },
    new Player { ID = 47, Name = "Jordan Pickford", Position = "GoalKeeper", TshirtNumber = 1, Age = 28, CountryID = 10, FantasyPrice = 100 },
    new Player { ID = 48, Name = "Raheem Sterling", Position = "Forward", TshirtNumber = 10, Age = 28, CountryID = 10, FantasyPrice = 78 },
    new Player { ID = 49, Name = "Declan Rice", Position = "MidFielder", TshirtNumber = 4, Age = 23, CountryID = 10, FantasyPrice = 20 },
    new Player { ID = 50, Name = "Harry Maguire", Position = "Defender", TshirtNumber = 6, Age = 29, CountryID = 10, FantasyPrice = 30 },

    // Players for Denmark (ID: 11)
    new Player { ID = 51, Name = "Christian Eriksen", Position = "MidFielder", TshirtNumber = 10, Age = 30, CountryID = 11, FantasyPrice = 75 },
    new Player { ID = 52, Name = "Kasper Schmeichel", Position = "GoalKeeper", TshirtNumber = 1, Age = 35, CountryID = 11, FantasyPrice = 23 },
    new Player { ID = 53, Name = "Andreas Christensen", Position = "Defender", TshirtNumber = 6, Age = 25, CountryID = 11, FantasyPrice = 60 },
    new Player { ID = 54, Name = "Yussuf Poulsen", Position = "Forward", TshirtNumber = 20, Age = 27, CountryID = 11, FantasyPrice = 12 },
    new Player { ID = 55, Name = "Pierre-Emile Hojbjerg", Position = "MidFielder", TshirtNumber = 5, Age = 25, CountryID = 11, FantasyPrice = 33 },

    // Players for Slovenia (ID: 12)
    new Player { ID = 56, Name = "Jan Oblak", Position = "GoalKeeper", TshirtNumber = 1, Age = 29, CountryID = 12, FantasyPrice = 10 },
    new Player { ID = 57, Name = "Josip Ilicic", Position = "Forward", TshirtNumber = 9, Age = 33, CountryID = 12, FantasyPrice = 12 },
    new Player { ID = 58, Name = "Benjamin Verbic", Position = "MidFielder", TshirtNumber = 7, Age = 27, CountryID = 12, FantasyPrice = 33 },
    new Player { ID = 59, Name = "Miha Mevlja", Position = "Defender", TshirtNumber = 6, Age = 31, CountryID = 12, FantasyPrice = 22 },
    new Player { ID = 60, Name = "Haris Vuckic", Position = "MidFielder", TshirtNumber = 11, Age = 29, CountryID = 12, FantasyPrice = 12 },

    // Players for Serbia (ID: 13)
    new Player { ID = 61, Name = "Nemanja Matic", Position = "MidFielder", TshirtNumber = 21, Age = 33, CountryID = 13, FantasyPrice = 28 },
    new Player { ID = 62, Name = "Dusan Tadic", Position = "Forward", TshirtNumber = 10, Age = 32, CountryID = 13, FantasyPrice = 30 },
    new Player { ID = 63, Name = "Aleksandar Mitrovic", Position = "Forward", TshirtNumber = 9, Age = 27, CountryID = 13, FantasyPrice = 65 },
    new Player { ID = 64, Name = "Stefan Mitrovic", Position = "Defender", TshirtNumber = 13, Age = 32, CountryID = 13, FantasyPrice = 22 },
    new Player { ID = 65, Name = "Sergej Milinkovic-Savic", Position = "MidFielder", TshirtNumber = 20, Age = 27, CountryID = 13, FantasyPrice = 33 },

    // Players for Netherlands (ID: 14)
    new Player { ID = 66, Name = "Memphis Depay", Position = "Forward", TshirtNumber = 10, Age = 28, CountryID = 14, FantasyPrice = 80 },
    new Player { ID = 67, Name = "Georginio Wijnaldum", Position = "MidFielder", TshirtNumber = 8, Age = 30, CountryID = 14, FantasyPrice = 35 },
    new Player { ID = 68, Name = "Matthijs de Ligt", Position = "Defender", TshirtNumber = 3, Age = 23, CountryID = 14, FantasyPrice = 78 },
    new Player { ID = 69, Name = "Denzel Dumfries", Position = "Defender", TshirtNumber = 22, Age = 25, CountryID = 14, FantasyPrice = 50 },
    new Player { ID = 70, Name = "Frenkie de Jong", Position = "MidFielder", TshirtNumber = 21, Age = 25, CountryID = 14, FantasyPrice = 100 },

    // Players for France (ID: 15)
    new Player { ID = 71, Name = "Kylian Mbappe", Position = "Forward", TshirtNumber = 10, Age = 23, CountryID = 15, FantasyPrice = 200 },
    new Player { ID = 72, Name = "Antoine Griezmann", Position = "Forward", TshirtNumber = 7, Age = 30, CountryID = 15, FantasyPrice = 100 },
    new Player { ID = 73, Name = "Paul Pogba", Position = "MidFielder", TshirtNumber = 6, Age = 30, CountryID = 15, FantasyPrice = 60 },
    new Player { ID = 74, Name = "Raphael Varane", Position = "Defender", TshirtNumber = 4, Age = 28, CountryID = 15, FantasyPrice = 100 },
    new Player { ID = 75, Name = "Hugo Lloris", Position = "GoalKeeper", TshirtNumber = 1, Age = 35, CountryID = 15, FantasyPrice = 100 },

    // Players for Austria (ID: 16)
    new Player { ID = 76, Name = "David Alaba", Position = "Defender", TshirtNumber = 8, Age = 29, CountryID = 16, FantasyPrice = 100 },
    new Player { ID = 77, Name = "Marko Arnautovic", Position = "Forward", TshirtNumber = 7, Age = 32, CountryID = 16, FantasyPrice = 70 },
    new Player { ID = 78, Name = "Marcel Sabitzer", Position = "MidFielder", TshirtNumber = 9, Age = 27, CountryID = 16, FantasyPrice = 23 },
    new Player { ID = 79, Name = "Stefan Lainer", Position = "Defender", TshirtNumber = 22, Age = 29, CountryID = 16, FantasyPrice = 11 },
    new Player { ID = 80, Name = "Konrad Laimer", Position = "MidFielder", TshirtNumber = 14, Age = 24, CountryID = 16, FantasyPrice = 22 },

    // Players for Poland (ID: 17)
    new Player { ID = 81, Name = "Robert Lewandowski", Position = "Forward", TshirtNumber = 9, Age = 32, CountryID = 17, FantasyPrice = 80 },
    new Player { ID = 82, Name = "Wojciech Szczesny", Position = "GoalKeeper", TshirtNumber = 1, Age = 31, CountryID = 17, FantasyPrice = 22 },
    new Player { ID = 83, Name = "Arkadiusz Milik", Position = "Forward", TshirtNumber = 7, Age = 28, CountryID = 17, FantasyPrice = 33 },
    new Player { ID = 84, Name = "Kamil Glik", Position = "Defender", TshirtNumber = 15, Age = 33, CountryID = 17, FantasyPrice = 11 },
    new Player { ID = 85, Name = "Piotr Zielinski", Position = "MidFielder", TshirtNumber = 19, Age = 27, CountryID = 17, FantasyPrice = 25 },

    // Players for Romania (ID: 18)
    new Player { ID = 86, Name = "Ianis Hagi", Position = "MidFielder", TshirtNumber = 10, Age = 23, CountryID = 18, FantasyPrice = 12 },
    new Player { ID = 87, Name = "Florin Andone", Position = "Forward", TshirtNumber = 11, Age = 28, CountryID = 18, FantasyPrice = 7 },
    new Player { ID = 88, Name = "Ciprian Tatarusanu", Position = "GoalKeeper", TshirtNumber = 1, Age = 34, CountryID = 18, FantasyPrice = 8 },
    new Player { ID = 89, Name = "Vlad Chiriches", Position = "Defender", TshirtNumber = 3, Age = 32, CountryID = 18, FantasyPrice = 11 },
    new Player { ID = 90, Name = "Alexandru Mitrita", Position = "Forward", TshirtNumber = 20, Age = 26, CountryID = 18, FantasyPrice = 22 },

    // Players for Belgium (ID: 19)
    new Player { ID = 91, Name = "Kevin De Bruyne", Position = "MidFielder", TshirtNumber = 7, Age = 30, CountryID = 19, FantasyPrice = 100 },
    new Player { ID = 92, Name = "Romelu Lukaku", Position = "Forward", TshirtNumber = 9, Age = 28, CountryID = 19, FantasyPrice = 100 },
    new Player { ID = 93, Name = "Thibaut Courtois", Position = "GoalKeeper", TshirtNumber = 1, Age = 31, CountryID = 19, FantasyPrice = 100 },
    new Player { ID = 94, Name = "Toby Alderweireld", Position = "Defender", TshirtNumber = 2, Age = 33, CountryID = 19, FantasyPrice = 44 },
    new Player { ID = 95, Name = "Youri Tielemans", Position = "MidFielder", TshirtNumber = 8, Age = 25, CountryID = 19, FantasyPrice = 35 },

    // Players for Slovakia (ID: 20)
    new Player { ID = 96, Name = "Milan Skriniar", Position = "Defender", TshirtNumber = 14, Age = 27, CountryID = 20, FantasyPrice = 22 },
    new Player { ID = 97, Name = "Martin Dubravka", Position = "GoalKeeper", TshirtNumber = 1, Age = 32, CountryID = 20, FantasyPrice = 12 },
    new Player { ID = 98, Name = "Juraj Kucka", Position = "MidFielder", TshirtNumber = 19, Age = 34, CountryID = 20, FantasyPrice = 66 },
    new Player { ID = 99, Name = "Robert Mak", Position = "MidFielder", TshirtNumber = 20, Age = 30, CountryID = 20, FantasyPrice = 34 },
    new Player { ID = 100, Name = "Ondrej Duda", Position = "Forward", TshirtNumber = 22, Age = 26, CountryID = 20, FantasyPrice = 17 },

    // Players for Ukraine (ID: 21)
    new Player { ID = 101, Name = "Andriy Yarmolenko", Position = "Forward", TshirtNumber = 7, Age = 32, CountryID = 21, FantasyPrice = 40 },
    new Player { ID = 102, Name = "Oleksandr Zinchenko", Position = "MidFielder", TshirtNumber = 17, Age = 25, CountryID = 21, FantasyPrice = 60 },
    new Player { ID = 103, Name = "Mykola Matviyenko", Position = "Defender", TshirtNumber = 22, Age = 25, CountryID = 21, FantasyPrice = 34 },
    new Player { ID = 104, Name = "Andriy Pyatov", Position = "GoalKeeper", TshirtNumber = 12, Age = 37, CountryID = 21, FantasyPrice = 100 },
    new Player { ID = 105, Name = "Roman Yaremchuk", Position = "Forward", TshirtNumber = 9, Age = 26, CountryID = 21, FantasyPrice = 30 },

    // Players for Portugal (ID: 22)
    new Player { ID = 106, Name = "Cristiano Ronaldo", Position = "Forward", TshirtNumber = 7, Age = 39, CountryID = 22, FantasyPrice = 100 },
    new Player { ID = 107, Name = "Bruno Fernandes", Position = "MidFielder", TshirtNumber = 8, Age = 29, CountryID = 22, FantasyPrice = 100 },
    new Player { ID = 108, Name = "Ruben Dias", Position = "Defender", TshirtNumber = 3, Age = 26, CountryID = 22, FantasyPrice = 100 },
    new Player { ID = 109, Name = "Rui Patricio", Position = "GoalKeeper", TshirtNumber = 1, Age = 36, CountryID = 22, FantasyPrice = 50 },
    new Player { ID = 110, Name = "Joao Felix", Position = "Forward", TshirtNumber = 21, Age = 23, CountryID = 22, FantasyPrice = 70 },

    // Players for Turkey (ID: 23)
    new Player { ID = 111, Name = "Burak Yilmaz", Position = "Forward", TshirtNumber = 17, Age = 36, CountryID = 23, FantasyPrice = 11 },
    new Player { ID = 112, Name = "Hakan Calhanoglu", Position = "MidFielder", TshirtNumber = 10, Age = 28, CountryID = 23, FantasyPrice = 70 },
    new Player { ID = 113, Name = "Merih Demiral", Position = "Defender", TshirtNumber = 3, Age = 24, CountryID = 23, FantasyPrice = 20 },
    new Player { ID = 114, Name = "Ugurcan Cakir", Position = "GoalKeeper", TshirtNumber = 23, Age = 26, CountryID = 23, FantasyPrice = 20 },
    new Player { ID = 115, Name = "Cengiz Under", Position = "Forward", TshirtNumber = 17, Age = 24, CountryID = 23, FantasyPrice = 22 },

    // Players for Czech Republic (ID: 24)
    new Player { ID = 116, Name = "Tomas Soucek", Position = "MidFielder", TshirtNumber = 15, Age = 27, CountryID = 24, FantasyPrice = 5 },
    new Player { ID = 117, Name = "Patrik Schick", Position = "Forward", TshirtNumber = 10, Age = 26, CountryID = 24, FantasyPrice = 8 },
    new Player { ID = 118, Name = "Tomas Vaclik", Position = "GoalKeeper", TshirtNumber = 1, Age = 32, CountryID = 24, FantasyPrice = 10 },
    new Player { ID = 119, Name = "Vladimir Coufal", Position = "Defender", TshirtNumber = 5, Age = 29, CountryID = 24, FantasyPrice = 8 },
    new Player { ID = 120, Name = "Antonin Barak", Position = "MidFielder", TshirtNumber = 9, Age = 27, CountryID = 24, FantasyPrice = 10 }



        );
        }
        
    }
}
