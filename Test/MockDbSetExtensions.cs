using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	public static class MockDbSetExtensions
	{
		public static Mock<DbSet<T>> CreateMockSet<T>(this IEnumerable<T> data) where T : class
		{
			var queryable = data.AsQueryable();
			var mockSet = new Mock<DbSet<T>>();

			mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

			return mockSet;
		}

		public static void SeedData_PublicMatchContext(MatchContext _context)
		{
			var matches = new List<Matches>
		{
			new Matches { ID = 1, Group = "A", IsFinished = false, HomeCountryID = 1, AwayCountryID = 2, MatchResults = new MatchResults { HomeScore = 1, AwayScore = 2 } },
			new Matches { ID = 2, Group = "A", IsFinished = true, HomeCountryID = 1, AwayCountryID = 3, MatchResults = new MatchResults { HomeScore = 2, AwayScore = 1 } },
			new Matches { ID = 3, Group = "B", IsFinished = false, HomeCountryID = 2, AwayCountryID = 3, MatchResults = new MatchResults { HomeScore = 3, AwayScore = 3 } },
			new Matches { ID = 4, Group = "B", IsFinished = true, HomeCountryID = 3, AwayCountryID = 1, MatchResults = new MatchResults { HomeScore = 1, AwayScore = 0 } }
		};

			_context.Matches.AddRange(matches);
			_context.SaveChanges();
		}

		public static void SeedData_PublicCountryContext(CountryContext _context)
		{
			var countries = new List<Countries>
			{
				new Countries {ID = 2, CountryName = "Germany" , Group = 'A', Matches = 3, GoalsAgainst = 2, GoalsFor = 8, Point = 7},
				new Countries {ID = 3, CountryName = "Switzerland" , Group = 'A', Matches = 3, GoalsAgainst = 3, GoalsFor = 5, Point = 5},
				new Countries {ID = 4, CountryName = "Hungary" , Group = 'A', Matches = 3, GoalsAgainst = 2, GoalsFor = 5, Point = 3},
				new Countries {ID = 5, CountryName = "Scotland" , Group = 'A', Matches = 3, GoalsAgainst = 2, GoalsFor = 7, Point = 1},

			};

			_context.Countries.AddRange(countries);
			_context.SaveChanges();
		}

		public static void SeedData_PublicFantasyContext(FantasyContext _context)
		{
			_context.Teams.AddRange(new List<FantasyTeam>
			{
				new FantasyTeam {ID = 1, TeamName = "team1", UserId = "userid1" },
				new FantasyTeam {ID = 2, TeamName = "team2", UserId = "userid2" },
			});

			_context.TeamPlayers.AddRange(new List<FantasyTeamPlayers>
			{
				new FantasyTeamPlayers {UserID = "userid1", PlayerId = 1, PlayerName = "player1"},
				new FantasyTeamPlayers {UserID = "userid2", PlayerId = 2, PlayerName = "player2"},

			});

			_context.SaveChanges();

		}

		public static void SeedData_PublicBetContext(BetContext _context)
		{
			_context.BetMatches.AddRange(new List<BetMatches>
		{
			new BetMatches { ID = 1, MatchId = 1, HomeCountryId = 1, HomeCountryName = "Country1", AwayCountryId = 2, AwayCountryName = "Country2", HomeCoefficient = 1.5M, DrawCoefficient = 3.0M, AwayCoefficient = 2.5M, isFinished = false },
			new BetMatches { ID = 2, MatchId = 2, HomeCountryId = 3, HomeCountryName = "Country3", AwayCountryId = 4, AwayCountryName = "Country4", HomeCoefficient = 1.7M, DrawCoefficient = 3.2M, AwayCoefficient = 2.7M, isFinished = true }
		});

			_context.Bets.AddRange(new List<Bet>
		{
			new Bet { ID = 1, BetID = "bet1", UserID = "user1", Coefficient = 1.5M, BetAmount = 100, DatePlaced = DateTime.Now, BetStatus = "Win" },
			new Bet { ID = 2, BetID = "bet2", UserID = "user2", Coefficient = 2.5M, BetAmount = 50, DatePlaced = DateTime.Now, BetStatus = "Lose" }
		});

			_context.SaveChanges();

		}

		public static void SeedData_PlayerContext(PlayerContext _context)
		{
			var players = new List<Player>
	{
		new Player { ID = 1, Name = "Player1", Position = "Forward", TshirtNumber = 9, Age = 28, CountryID = 1, FantasyPrice = 10.5M },
		new Player { ID = 2, Name = "Player2", Position = "Midfielder", TshirtNumber = 8, Age = 26, CountryID = 1, FantasyPrice = 9.0M },
		new Player { ID = 3, Name = "Player3", Position = "Defender", TshirtNumber = 5, Age = 24, CountryID = 2, FantasyPrice = 8.0M },
		new Player { ID = 4, Name = "Player4", Position = "Goalkeeper", TshirtNumber = 1, Age = 30, CountryID = 2, FantasyPrice = 7.0M },
		new Player { ID = 5, Name = "Player5", Position = "Forward", TshirtNumber = 11, Age = 27, CountryID = 3, FantasyPrice = 10.0M },
		new Player { ID = 6, Name = "Player6", Position = "Midfielder", TshirtNumber = 6, Age = 25, CountryID = 3, FantasyPrice = 9.5M },
		new Player { ID = 7, Name = "Player7", Position = "Defender", TshirtNumber = 4, Age = 23, CountryID = 4, FantasyPrice = 8.5M },
		new Player { ID = 8, Name = "Player8", Position = "Goalkeeper", TshirtNumber = 12, Age = 31, CountryID = 4, FantasyPrice = 7.5M },
		new Player { ID = 9, Name = "Player9", Position = "Forward", TshirtNumber = 10, Age = 29, CountryID = 5, FantasyPrice = 10.2M },
		new Player { ID = 10, Name = "Player10", Position = "Midfielder", TshirtNumber = 7, Age = 28, CountryID = 5, FantasyPrice = 9.8M }
	};

			_context.Players.AddRange(players);
			_context.SaveChanges();
		}



		public static void SeedData_WalletContext(WalletContext _context)
		{
			var wallets = new List<Wallet>
	{
		new Wallet { ID = 1, UserID = "user1", UserName = "User One", Balance = 100.00m },
		new Wallet { ID = 2, UserID = "user2", UserName = "User Two", Balance = 200.00m },
		new Wallet { ID = 3, UserID = "user3", UserName = "User Three", Balance = 300.00m },
	};

			_context.Wallet.AddRange(wallets);
			_context.SaveChanges();
		}
	}



}
