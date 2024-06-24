using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options)
        {

        }

        public DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>().HasData(
                new Countries { ID = 1, CountryName = "Georgia", Group = 'F', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 2, CountryName = "Germany", Group = 'A', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 3, CountryName = "Switzerland", Group = 'A', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 4, CountryName = "Scotland", Group = 'A', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 5, CountryName = "Hungary", Group = 'A', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 6, CountryName = "Spain", Group = 'B', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 7, CountryName = "Italy", Group = 'B', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 8, CountryName = "Albania", Group = 'B', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 9, CountryName = "Croatia", Group = 'B', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 10, CountryName = "England", Group = 'C', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 11, CountryName = "Denmark", Group = 'C', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 12, CountryName = "Slovenia", Group = 'C', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 13, CountryName = "Serbia", Group = 'C', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 14, CountryName = "Netherlands", Group = 'D', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 15, CountryName = "France", Group = 'D', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 16, CountryName = "Austria", Group = 'D', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 17, CountryName = "Poland", Group = 'D', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 18, CountryName = "Romania", Group = 'E', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 19, CountryName = "Belgium", Group = 'E', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 20, CountryName = "Slovakia", Group = 'E', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 21, CountryName = "Ukraine", Group = 'E', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 22, CountryName = "Portugal", Group = 'F', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 23, CountryName = "Turkey", Group = 'F', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 },
                new Countries { ID = 24, CountryName = "Czech Republic", Group = 'F', Point = 0, Matches = 0, GoalsFor = 0, GoalsAgainst = 0 }
            );
        }
    }
}
