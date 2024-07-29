using Euro2024Stat.BetAPI.Service;
using Euro2024Stat.PlayerAPI.Models.Dto;
using Euro2024Stat.PlayerAPI.Service;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test_PublicPlayer
{
	public class Test_PublicPlayer
	{
		private readonly DbContextOptions<PlayerContext> _options;
		private readonly PlayerContext _context;
		private readonly PlayerService _service;


		public Test_PublicPlayer()
		{
			_options = new DbContextOptionsBuilder<PlayerContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new PlayerContext(_options);
			_service = new PlayerService(_context);

			MockDbSetExtensions.SeedData_PlayerContext(_context);
		}


		[Theory]
		[InlineData(1, "Player1", "Forward", 9, 28, 1, 10.5)]
		[InlineData(5, "Player5", "Forward", 11, 27, 3, 10.0)]
		[InlineData(10, "Player10", "Midfielder", 7, 28, 5, 9.8)]
		public async Task GetPlayerById_WithValidId_ReturnsExpectedPlayer(int id, string expectedName, string expectedPosition, int expectedTshirtNumber, int expectedAge, int expectedCountryID, decimal expectedFantasyPrice)
		{
			// Act
			var player = await _service.GetPlayerById(id);

			// Assert
			Assert.NotNull(player);
			Assert.Equal(expectedName, player.Name);
			Assert.Equal(expectedPosition, player.Position);
			Assert.Equal(expectedTshirtNumber, player.TshirtNumber);
			Assert.Equal(expectedAge, player.Age);
			Assert.Equal(expectedCountryID, player.CountryID);
			Assert.Equal(expectedFantasyPrice, player.FantasyPrice);
		}

		[Theory]
		[InlineData(new[] { 1, 3, 5 }, 3)]
		[InlineData(new[] { 2, 4, 6, 8, 10 }, 5)]
		public async Task GetPlayersByPlayerIds_WithValidIds_ReturnsExpectedPlayers(int[] playerIds, int expectedCount)
		{
			// Arrange
			var playerDtos = playerIds.Select(id => new FantasyPlayerDto { PlayerId = id }).ToList();

			// Act
			var players = await _service.GetPlayersByPlayerIds(playerDtos);

			// Assert
			Assert.NotNull(players);
			Assert.Equal(expectedCount, players.Count());
		}

		
	}
}
