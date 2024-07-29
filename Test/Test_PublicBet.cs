using EURO2024Stat.DATA;
using Euro2024Stat.FantasyAPI.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using Euro2024Stat.BetAPI.Service;
using EURO2024Stat.Domain;
using Euro2024Stat.MatchAPI.Service;
using Moq;

namespace Test_PublicBet
{
	public class Test_PublicBet
	{
		private readonly DbContextOptions<BetContext> _options;
		private readonly BetContext _context;
		private readonly PublicBetService _service;


		public Test_PublicBet()
		{
			_options = new DbContextOptionsBuilder<BetContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new BetContext(_options);
			_service = new PublicBetService(_context);

			MockDbSetExtensions.SeedData_PublicBetContext(_context);
		}


		[Theory]
		[InlineData("user3", 1.8, 200, "Pending", true)]
		[InlineData("user4", 2.1, 150, "Win", true)]
		[InlineData(null, 1.8, 200, "Pending", false)] // Invalid data
		public async Task PlaceBet_WithVariousData_ReturnsExpectedResult(string userId, decimal coefficient, decimal betAmount, string betStatus, bool expectedResult)
		{
			// Arrange
			var newBet = userId != null ? new Bet
			{
				UserID = userId,
				Coefficient = coefficient,
				BetAmount = betAmount,
				BetStatus = betStatus
			} : null;

			// Act
			var result = await _service.PlaceBet(newBet);

			// Assert
			Assert.Equal(expectedResult, result);

			if (expectedResult)
			{
				var bet = await _context.Bets.SingleOrDefaultAsync(b => b.UserID == userId);
				Assert.NotNull(bet);
				Assert.Equal(newBet.Coefficient, bet.Coefficient);
				Assert.Equal(newBet.BetAmount, bet.BetAmount);
				Assert.Equal(newBet.BetStatus, bet.BetStatus);
			}
		}

		[Fact]
		public async Task GetAllBettingMatches_ReturnsAllBetMatches()
		{
			// Act
			var result = await _service.GetAllBettingMatches();

			// Assert
			Assert.Equal(2, result.Count());
		}

		[Theory]
		[InlineData("user1", "Win")]
		[InlineData("user2", "Lose")]
		public async Task GetBetsByUserId_ReturnsBetsForSpecificUser(string userId, string betStatus)
		{
			// Arange
			var result = await _service.GetBetsByUserId(userId);

			// Assert
			Assert.Equal(betStatus, result.First().BetStatus);
		}

		[Fact]
		public async Task PlaceBet_ReturnsFalseIfModelIsNull()
		{
			// Act
			var result = await _service.PlaceBet(null);

			// Assert
			Assert.False(result);
		}

		
	}
}
