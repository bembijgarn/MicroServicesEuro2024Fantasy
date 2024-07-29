using EURO2024Stat.DATA;
using Euro2024Stat.MatchAPI.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using EURO2024Stat.Domain;

namespace Test_PrivateMatch
{
	public class Test_PrivateMatch
	{
		private readonly DbContextOptions<MatchContext> _options;
		private readonly MatchContext _context;
		private readonly PrivateMatchService _service;


		public Test_PrivateMatch()
		{
			_options = new DbContextOptionsBuilder<MatchContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new MatchContext(_options);
			_service = new PrivateMatchService(_context);

			MockDbSetExtensions.SeedData_PublicMatchContext(_context);
		}


		[Fact]
		public async Task EditMatchResult_UpdatesMatchResults()
		{
			// Arrange
			var matchId = 1;
			var newResult = new MatchResults { HomeScore = 3, AwayScore = 2 };

			// Act
			await _service.EditMatchResult(matchId, newResult);

			// Assert
			var match = await _context.Matches.Include(m => m.MatchResults).FirstOrDefaultAsync(m => m.ID == matchId);
			Assert.True(match.IsFinished);
			Assert.Equal(3, match.MatchResults.HomeScore);
			Assert.Equal(2, match.MatchResults.AwayScore);
		}

		[Fact]
		public async Task ResetMatch_ResetsMatchResults()
		{
			// Arrange
			var matchId = 1;

			// Act
			await _service.ResetMatch(matchId);

			// Assert
			var match = await _context.Matches.Include(m => m.MatchResults).FirstOrDefaultAsync(m => m.ID == matchId);
			Assert.False(match.IsFinished);
			Assert.Equal(0, match.MatchResults.HomeScore);
			Assert.Equal(0, match.MatchResults.AwayScore);
		}

		[Fact]
		public async Task FinishMatch_SetsMatchAsFinished()
		{
			// Arrange
			var matchId = 3;

			// Act
			await _service.FinishMatch(matchId);

			// Assert
			var match = await _context.Matches.FirstOrDefaultAsync(m => m.ID == matchId);
			Assert.True(match.IsFinished);
		}

		[Fact]
		public async Task CreatePlayOffMatch_AddsNewMatch()
		{
			// Arrange
			var newMatch = new Matches { ID = 5, Group = "C", IsFinished = false, HomeCountryID = 4, AwayCountryID = 5 };

			// Act
			await _service.CreatePlayOffMatch(newMatch);

			// Assert
			var match = await _context.Matches.FirstOrDefaultAsync(m => m.ID == 5);
			Assert.NotNull(match);
			Assert.Equal(0, match.MatchResults.HomeScore);
			Assert.Equal(0, match.MatchResults.AwayScore);
		}

		[Fact]
		public async Task GetPlayoffMatchCountryIds_ReturnsCountryIds()
		{
			// Arrange
			var group = "A";

			// Act
			var result = await _service.GetPlayoffMatchCountryIds(group);

			// Assert
			var expectedIds = new List<int> { 1, 2, 3 };
			Assert.Equal(expectedIds.Count, result.Count);
			Assert.All(expectedIds, id => Assert.Contains(id, result));
		}

		

		[Fact]
		public async Task GetWinnerTeamId_ReturnsWinningTeamId()
		{
			// Arrange
			var group = "A";

			// Act
			var result = await _service.GetWinnerTeamId(group);

			// Assert
			var expectedId = 2;
			Assert.Equal(expectedId, result);
		}

		[Fact]
		public async Task GetLastMatchId_ReturnsLastMatchId()
		{
			// Act
			var result = await _service.GetLastMatchId();

			// Assert
			var expectedId = 4;
			Assert.Equal(expectedId, result);
		}
	}
}
