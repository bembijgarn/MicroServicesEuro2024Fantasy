using Euro2024Stat.CountryAPI.Service;
using Euro2024Stat.FantasyAPI.Service;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test_Fantasy
{
	public class Test_Fantasy
	{
		private readonly DbContextOptions<FantasyContext> _options;
		private readonly FantasyContext _context;
		private readonly PublicFantasyService _service;


		public Test_Fantasy()
		{
			_options = new DbContextOptionsBuilder<FantasyContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new FantasyContext(_options);
			_service = new PublicFantasyService(_context);

			MockDbSetExtensions.SeedData_PublicFantasyContext(_context);
		}


		[Fact]
		public async Task BuyPlayer_AddsPlayerToTeam()
		{
			// Arrange
			var userId = "userid1";
			var playerId = 3;
			var playerName = "Player3";

			// Act
			await _service.BuyPlayer(userId, playerId, playerName);

			// Assert
			var player = await _context.TeamPlayers.SingleOrDefaultAsync(tp => tp.UserID == userId && tp.PlayerId == playerId);
			Assert.NotNull(player);
			Assert.Equal(playerName, player.PlayerName);
		}

		[Fact]
		public async Task SellPlayer_RemovesPlayerFromTeam()
		{
			// Arrange
			var userId = "userid1";
			var playerId = 1;

			// Act
			await _service.SellPlayer(userId, playerId);

			// Assert
			var player = await _context.TeamPlayers.SingleOrDefaultAsync(tp => tp.UserID == userId && tp.PlayerId == playerId);
			Assert.Null(player);
		}

		[Fact]
		public async Task CreateTeam_AddsNewTeam()
		{
			// Arrange
			var newTeam = new FantasyTeam { UserId = "userid3", ID = 3 };

			// Act
			await _service.CreateTeam(newTeam);

			// Assert
			var team = await _context.Teams.SingleOrDefaultAsync(t => t.UserId == "userid3");
			Assert.NotNull(team);
			Assert.Equal(3, team.ID);
		}

		[Fact]
		public async Task GetPlayerIds_ReturnsPlayersForUser()
		{
			// Arrange
			var userId = "userid1";

			// Act
			var playerIds = await _service.GetPlayerIds(userId);

			// Assert
			Assert.Single(playerIds);
			Assert.Equal(1, playerIds.First().PlayerId);
		}

		[Fact]
		public async Task HaveUserFantasy_ReturnsTrueIfUserHasTeam()
		{
			// Arrange
			var userId = "userid1";

			// Act
			var result = await _service.HaveUserFantasy(userId);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public async Task HaveUserFantasy_ReturnsFalseIfUserDoesNotHaveTeam()
		{
			// Arrange
			var userId = "userid3";

			// Act
			var result = await _service.HaveUserFantasy(userId);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public async Task GetTeamIdByUserId_ReturnsTeamIdForUser()
		{
			// Arrange
			var userId = "userid1";

			// Act
			var teamId = await _service.GetTeamIdByUserId(userId);

			// Assert
			Assert.Equal(1, teamId);
		}

		[Fact]
		public async Task CreateMatchResult_AddsNewMatchResult()
		{
			// Arrange
			var teamId = 1;
			var result = "Win";

			// Act
			await _service.CreateMatchResult(teamId, result);

			// Assert
			var matchResult = await _context.MatchResults.SingleOrDefaultAsync(mr => mr.TeamID == teamId);
			Assert.NotNull(matchResult);
			Assert.Equal(result, matchResult.Result);
		}

		[Fact]
		public async Task GetMatchResultsByTeamId_ReturnsMatchResults()
		{
			// Arrange
			var teamId = 1;
			var result = "Win";
			var matchResult = new FantasyMatchResults
			{
				TeamID = teamId,
				Result = result
			};
			_context.MatchResults.Add(matchResult);
			await _context.SaveChangesAsync();

			// Act
			var matchResults = await _service.GetMatchResultsByTeamId(teamId);

			// Assert
			Assert.Single(matchResults);
			Assert.Equal(result, matchResults.First().Result);
		}
	}
}
