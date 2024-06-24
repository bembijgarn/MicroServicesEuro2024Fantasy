using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURO2024Stat.DATA
{
	public class MatchContext : DbContext
	{
		public MatchContext(DbContextOptions<MatchContext> options) : base(options)
		{

		}

		public DbSet<Matches> Matches { get; set; }
		public DbSet<MatchResults> MatchResults { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Matches>()
			.HasOne(m => m.MatchResults)
			.WithOne(mr => mr.Match)
			.HasForeignKey<MatchResults>(mr => mr.MatchID);

			modelBuilder.Entity<Matches>().HasData(

		// Group A Matches
		new Matches { ID = 1, HomeCountryID = 2, AwayCountryID = 4, Stadium = "Allianz Arena, Munich", MatchDatetime = new DateTime(2024, 6, 14, 21, 0, 0), IsFinished = false, Group = "A" },
		new Matches { ID = 2, HomeCountryID = 3, AwayCountryID = 5, Stadium = "Olympiastadion, Berlin", MatchDatetime = new DateTime(2024, 6, 15, 15, 0, 0), IsFinished = false, Group = "A" },
		new Matches { ID = 3, HomeCountryID = 2, AwayCountryID = 5, Stadium = "Allianz Arena, Munich", MatchDatetime = new DateTime(2024, 6, 20, 21, 0, 0), IsFinished = false, Group = "A" },
		new Matches { ID = 4, HomeCountryID = 4, AwayCountryID = 3, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 21, 18, 0, 0), IsFinished = false, Group = "A" },
		new Matches { ID = 5, HomeCountryID = 2, AwayCountryID = 3, Stadium = "Volksparkstadion, Hamburg", MatchDatetime = new DateTime(2024, 6, 25, 21, 0, 0), IsFinished = false, Group = "A" },
		new Matches { ID = 6, HomeCountryID = 4, AwayCountryID = 5, Stadium = "Olympiastadion, Berlin", MatchDatetime = new DateTime(2024, 6, 26, 18, 0, 0), IsFinished = false, Group = "A" },

		// Group B Matches
		new Matches { ID = 7, HomeCountryID = 6, AwayCountryID = 9, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 15, 18, 0, 0), IsFinished = false, Group = "B" },
		new Matches { ID = 8, HomeCountryID = 7, AwayCountryID = 8, Stadium = "RheinEnergieStadion, Cologne", MatchDatetime = new DateTime(2024, 6, 15, 21, 0, 0), IsFinished = false, Group = "B" },
		new Matches { ID = 9, HomeCountryID = 6, AwayCountryID = 8, Stadium = "Olympiastadion, Berlin", MatchDatetime = new DateTime(2024, 6, 20, 18, 0, 0), IsFinished = false, Group = "B" },
		new Matches { ID = 10, HomeCountryID = 9, AwayCountryID = 7, Stadium = "Allianz Arena, Munich", MatchDatetime = new DateTime(2024, 6, 21, 21, 0, 0), IsFinished = false, Group = "B" },
		new Matches { ID = 11, HomeCountryID = 6, AwayCountryID = 7, Stadium = "Volksparkstadion, Hamburg", MatchDatetime = new DateTime(2024, 6, 25, 18, 0, 0), IsFinished = false, Group = "B" },
		new Matches { ID = 12, HomeCountryID = 9, AwayCountryID = 8, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 26, 21, 0, 0), IsFinished = false, Group = "B" },

		// Group C Matches
		new Matches { ID = 13, HomeCountryID = 10, AwayCountryID = 12, Stadium = "Veltins-Arena, Gelsenkirchen", MatchDatetime = new DateTime(2024, 6, 16, 21, 0, 0), IsFinished = false, Group = "C" },
		new Matches { ID = 14, HomeCountryID = 11, AwayCountryID = 13, Stadium = "Volksparkstadion, Hamburg", MatchDatetime = new DateTime(2024, 6, 17, 18, 0, 0), IsFinished = false, Group = "C" },
		new Matches { ID = 15, HomeCountryID = 10, AwayCountryID = 13, Stadium = "Commerzbank-Arena, Frankfurt", MatchDatetime = new DateTime(2024, 6, 22, 21, 0, 0), IsFinished = false, Group = "C" },
		new Matches { ID = 16, HomeCountryID = 12, AwayCountryID = 11, Stadium = "Volksparkstadion, Hamburg", MatchDatetime = new DateTime(2024, 6, 23, 18, 0, 0), IsFinished = false, Group = "C" },
		new Matches { ID = 17, HomeCountryID = 10, AwayCountryID = 11, Stadium = "Veltins-Arena, Gelsenkirchen", MatchDatetime = new DateTime(2024, 6, 27, 21, 0, 0), IsFinished = false, Group = "C" },
		new Matches { ID = 18, HomeCountryID = 12, AwayCountryID = 13, Stadium = "Commerzbank-Arena, Frankfurt", MatchDatetime = new DateTime(2024, 6, 28, 18, 0, 0), IsFinished = false, Group = "C" },

		// Group D Matches
		new Matches { ID = 19, HomeCountryID = 14, AwayCountryID = 17, Stadium = "Red Bull Arena, Leipzig", MatchDatetime = new DateTime(2024, 6, 16, 15, 0, 0), IsFinished = false, Group = "D" },
		new Matches { ID = 20, HomeCountryID = 15, AwayCountryID = 16, Stadium = "Esprit Arena, Düsseldorf", MatchDatetime = new DateTime(2024, 6, 16, 18, 0, 0), IsFinished = false, Group = "D" },
		new Matches { ID = 21, HomeCountryID = 14, AwayCountryID = 16, Stadium = "Red Bull Arena, Leipzig", MatchDatetime = new DateTime(2024, 6, 21, 15, 0, 0), IsFinished = false, Group = "D" },
		new Matches { ID = 22, HomeCountryID = 17, AwayCountryID = 15, Stadium = "Esprit Arena, Düsseldorf", MatchDatetime = new DateTime(2024, 6, 22, 18, 0, 0), IsFinished = false, Group = "D" },
		new Matches { ID = 23, HomeCountryID = 14, AwayCountryID = 15, Stadium = "Commerzbank-Arena, Frankfurt", MatchDatetime = new DateTime(2024, 6, 26, 15, 0, 0), IsFinished = false, Group = "D" },
		new Matches { ID = 24, HomeCountryID = 17, AwayCountryID = 16, Stadium = "Red Bull Arena, Leipzig", MatchDatetime = new DateTime(2024, 6, 27, 18, 0, 0), IsFinished = false, Group = "D" },

		// Group E Matches
		new Matches { ID = 25, HomeCountryID = 18, AwayCountryID = 21, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 18, 15, 0, 0), IsFinished = false, Group = "E" },
		new Matches { ID = 26, HomeCountryID = 19, AwayCountryID = 20, Stadium = "Commerzbank-Arena, Frankfurt", MatchDatetime = new DateTime(2024, 6, 18, 18, 0, 0), IsFinished = false, Group = "E" },
		new Matches { ID = 27, HomeCountryID = 18, AwayCountryID = 20, Stadium = "Red Bull Arena, Leipzig", MatchDatetime = new DateTime(2024, 6, 23, 15, 0, 0), IsFinished = false, Group = "E" },
		new Matches { ID = 28, HomeCountryID = 21, AwayCountryID = 19, Stadium = "Olympiastadion, Berlin", MatchDatetime = new DateTime(2024, 6, 23, 21, 0, 0), IsFinished = false, Group = "E" },
		new Matches { ID = 29, HomeCountryID = 18, AwayCountryID = 19, Stadium = "Esprit Arena, Düsseldorf", MatchDatetime = new DateTime(2024, 6, 28, 15, 0, 0), IsFinished = false, Group = "E" },
		new Matches { ID = 30, HomeCountryID = 21, AwayCountryID = 20, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 28, 21, 0, 0), IsFinished = false, Group = "E" },

		// Group F Matches
		new Matches { ID = 31, HomeCountryID = 22, AwayCountryID = 23, Stadium = "RheinEnergieStadion, Cologne", MatchDatetime = new DateTime(2024, 6, 18, 15, 0, 0), IsFinished = false, Group = "F" },
		new Matches { ID = 32, HomeCountryID = 1, AwayCountryID = 24, Stadium = "Red Bull Arena, Leipzig", MatchDatetime = new DateTime(2024, 6, 18, 21, 0, 0), IsFinished = false, Group = "F" },
		new Matches { ID = 33, HomeCountryID = 22, AwayCountryID = 24, Stadium = "Mercedes-Benz Arena, Stuttgart", MatchDatetime = new DateTime(2024, 6, 23, 18, 0, 0), IsFinished = false, Group = "F" },
		new Matches { ID = 34, HomeCountryID = 23, AwayCountryID = 1, Stadium = "Allianz Arena, Munich", MatchDatetime = new DateTime(2024, 6, 23, 21, 0, 0), IsFinished = false, Group = "F" },
		new Matches { ID = 35, HomeCountryID = 22, AwayCountryID = 1, Stadium = "Volksparkstadion, Hamburg", MatchDatetime = new DateTime(2024, 6, 27, 18, 0, 0), IsFinished = false, Group = "F" },
		new Matches { ID = 36, HomeCountryID = 23, AwayCountryID = 24, Stadium = "Olympiastadion, Berlin", MatchDatetime = new DateTime(2024, 6, 27, 21, 0, 0), IsFinished = false, Group = "F" }
		);


			modelBuilder.Entity<MatchResults>(entity =>
			{
				entity.HasData(
					new MatchResults { ID = 1, MatchID = 1, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 2, MatchID = 2, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 3, MatchID = 3, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 4, MatchID = 4, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 5, MatchID = 5, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 6, MatchID = 6, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 7, MatchID = 7, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 8, MatchID = 8, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 9, MatchID = 9, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 10, MatchID = 10, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 11, MatchID = 11, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 12, MatchID = 12, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 13, MatchID = 13, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 14, MatchID = 14, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 15, MatchID = 15, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 16, MatchID = 16, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 17, MatchID = 17, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 18, MatchID = 18, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 19, MatchID = 19, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 20, MatchID = 20, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 21, MatchID = 21, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 22, MatchID = 22, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 23, MatchID = 23, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 24, MatchID = 24, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 25, MatchID = 25, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 26, MatchID = 26, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 27, MatchID = 27, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 28, MatchID = 28, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 29, MatchID = 29, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 30, MatchID = 30, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 31, MatchID = 31, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 32, MatchID = 32, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 33, MatchID = 33, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 34, MatchID = 34, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 35, MatchID = 35, HomeScore = 0, AwayScore = 0 },
					new MatchResults { ID = 36, MatchID = 36, HomeScore = 0, AwayScore = 0 }
				);
			});
		}


	}
}
