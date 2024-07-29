using Euro2024Stat.MatchAPI.Service;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;
using Test;

namespace Test_PublicMatch
{
	public class Test_PublicMatch
	{
		private readonly DbContextOptions<MatchContext> _options;
		private readonly MatchContext _context;
		private readonly PublicMatchService _service;

		public Test_PublicMatch()
		{
			_options = new DbContextOptionsBuilder<MatchContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new MatchContext(_options);
			_service = new PublicMatchService(_context);

			MockDbSetExtensions.SeedData_PublicMatchContext(_context);
		}

		

		[Fact]
		public async Task GetAllMatch_ReturnsUnfinishedMatches()
		{
			// Act
			var result = await _service.GetAllMatch();

			// Assert
			Assert.Equal(2, result.Count());
		}

		[Fact]
		public async Task GetAllMatchByCountryId_ReturnsMatchesForCountry()
		{
			// Arrange
			var countryId = 1;

			// Act
			var result = await _service.GetAllMatchByCountryId(countryId);

			// Assert
			Assert.Equal(3, result.Count());
		}

		[Fact]
		public async Task GetAllMatchByCountryId_ReturnsEmptyResult()
		{
			// Arrange
			var countryId = 100;

			// Act
			var result = await _service.GetAllMatchByCountryId(countryId);

			// Assert
			Assert.Empty(result);
		}

		[Fact]
		public async Task GetMatchesWithResults_ReturnsFinishedMatchesWithResults()
		{
			// Act
			var result = await _service.GetMatchesWithResults();

			// Assert
			Assert.Equal(2, result.Count());
		}

		[Fact]
		public async Task GetAllGroupMatchWithResultByGroupId_ReturnsFinishedGroupMatchesWithResults()
		{
			// Arrange
			var groupId = "A";

			// Act
			var result = await _service.GetAllGroupMatchWithResultByGroupId(groupId);

			// Assert
			Assert.Single(result);

		}
	}
}