using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
    public class BetContext : DbContext
    {
        public BetContext(DbContextOptions<BetContext> options) : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetMatches> BetMatches { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<BetMatches>().HasData(

                // Group A

                new BetMatches { ID = 1 ,MatchId = 1, HomeCountryId = 2,HomeCountryName = "Germany", AwayCountryId = 4,AwayCountryName = "Scotland" ,HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 2, MatchId = 2, HomeCountryId = 3, HomeCountryName = "Switzerland",  AwayCountryId = 5, AwayCountryName = "Hungary", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 3, MatchId = 3, HomeCountryId = 2, HomeCountryName = "Germany", AwayCountryId = 5, AwayCountryName = "Hungary", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 4, MatchId = 4, HomeCountryId = 4, HomeCountryName = "Scotnald", AwayCountryId = 3, AwayCountryName = "Switzerland", HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 5, MatchId = 5, HomeCountryId = 2, HomeCountryName = "Germany", AwayCountryId = 3, AwayCountryName = "Switzerland", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 6, MatchId = 6, HomeCountryId = 4, HomeCountryName = "Scotland", AwayCountryId = 5, AwayCountryName = "Hungary", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false },


                // Group B


                new BetMatches { ID = 7, MatchId = 7, HomeCountryId = 6, HomeCountryName = "Spain", AwayCountryId = 9, AwayCountryName = "Croatia", HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 8, MatchId = 8, HomeCountryId = 7, HomeCountryName = "Italy", AwayCountryId = 8, AwayCountryName = "Albania", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 9,  MatchId = 9, HomeCountryId = 6, HomeCountryName = "Spain", AwayCountryId = 8, AwayCountryName = "Albania", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 10, MatchId = 10, HomeCountryId = 9, HomeCountryName = "Croatia", AwayCountryId = 7, AwayCountryName = "Italy", HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 11, MatchId = 11, HomeCountryId = 6, HomeCountryName = "Spain", AwayCountryId = 7, AwayCountryName = "Italy", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 12, MatchId = 12, HomeCountryId = 9, HomeCountryName = "Croatia", AwayCountryId = 8, AwayCountryName = "Albania", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false },


                // Group C


                new BetMatches { ID = 13, MatchId = 13, HomeCountryId = 10, HomeCountryName = "England", AwayCountryId = 12, AwayCountryName = "Slovenia", HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 14, MatchId = 14, HomeCountryId = 11, HomeCountryName = "Denmark", AwayCountryId = 13, AwayCountryName = "Serbia", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 15, MatchId = 15, HomeCountryId = 10, HomeCountryName = "England", AwayCountryId = 13, AwayCountryName = "Serbia", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 16, MatchId = 16, HomeCountryId = 12, HomeCountryName = "Slovenia", AwayCountryId = 11, AwayCountryName = "Denmark", HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 17, MatchId = 17, HomeCountryId = 10, HomeCountryName = "England", AwayCountryId = 11, AwayCountryName = "Denmark", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 18, MatchId = 18, HomeCountryId = 12, HomeCountryName = "Slovenia", AwayCountryId = 13, AwayCountryName = "Serbia", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false },


                // Group D

                new BetMatches { ID = 19, MatchId = 19, HomeCountryId = 14, HomeCountryName = "Netherlands", AwayCountryId = 17, AwayCountryName = "Poland", HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 20, MatchId = 20, HomeCountryId = 15, HomeCountryName = "France", AwayCountryId = 16, AwayCountryName = "Austria", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 21, MatchId = 21, HomeCountryId = 14, HomeCountryName = "Netherlands", AwayCountryId = 16, AwayCountryName = "Austria", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 22, MatchId = 22, HomeCountryId = 17, HomeCountryName = "Poland", AwayCountryId = 15, AwayCountryName = "France",  HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 23, MatchId = 23, HomeCountryId = 14, HomeCountryName = "Netherlands", AwayCountryId = 15, AwayCountryName = "France", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 24, MatchId = 24, HomeCountryId = 17, HomeCountryName = "Poland", AwayCountryId = 16, AwayCountryName = "Austria", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false },

                // Group E

                new BetMatches { ID = 25, MatchId = 25, HomeCountryId = 18,HomeCountryName = "Romania", AwayCountryId = 21, AwayCountryName = "Ukraine", HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 26, MatchId = 26, HomeCountryId = 19, HomeCountryName = "Belgium", AwayCountryId = 20, AwayCountryName = "Slovakia", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 27, MatchId = 27, HomeCountryId = 18, HomeCountryName = "Romania", AwayCountryId = 20, AwayCountryName = "Slovakia", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 28, MatchId = 28, HomeCountryId = 21, HomeCountryName = "Ukraine", AwayCountryId = 19, AwayCountryName = "Belgium", HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 29, MatchId = 29, HomeCountryId = 18, HomeCountryName = "Romania", AwayCountryId = 19, AwayCountryName = "Belgium", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 30, MatchId = 30, HomeCountryId = 21, HomeCountryName = "Ukraine", AwayCountryId = 20, AwayCountryName = "Slovakia", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false },

                // Group F

                new BetMatches { ID = 31, MatchId = 31, HomeCountryId = 22, HomeCountryName = "Portugal", AwayCountryId = 23, AwayCountryName = "Turkey", HomeCoefficient = 1.4m, DrawCoefficient = 3.4m, AwayCoefficient = 5.6m, isFinished = false },
                new BetMatches { ID = 32, MatchId = 32, HomeCountryId = 1, HomeCountryName = "Georgia", AwayCountryId = 24, AwayCountryName = "Czech Republic", HomeCoefficient = 1.7m, DrawCoefficient = 3.5m, AwayCoefficient = 3.2m, isFinished = false },
                new BetMatches { ID = 33, MatchId = 33, HomeCountryId = 22, HomeCountryName = "Portugal", AwayCountryId = 24, AwayCountryName = "Czech Republic", HomeCoefficient = 1.6m, DrawCoefficient = 3.0m, AwayCoefficient = 8.0m, isFinished = false },
                new BetMatches { ID = 34, MatchId = 34, HomeCountryId = 23, HomeCountryName = "Turkey", AwayCountryId = 1, AwayCountryName = "Georgia", HomeCoefficient = 3.0m, DrawCoefficient = 3.7m, AwayCoefficient = 1.95m, isFinished = false },
                new BetMatches { ID = 35, MatchId = 35, HomeCountryId = 22, HomeCountryName = "Portugal", AwayCountryId = 1, AwayCountryName = "Georgia", HomeCoefficient = 1.5m, DrawCoefficient = 3.4m, AwayCoefficient = 3.5m, isFinished = false },
                new BetMatches { ID = 36, MatchId = 36, HomeCountryId = 23, HomeCountryName = "Turkey", AwayCountryId = 24, AwayCountryName = "Czech Republic", HomeCoefficient = 1.85m, DrawCoefficient = 3.7m, AwayCoefficient = 2.95m, isFinished = false }

                );

        }

    }
}
