using Euro2024Stat.CountryAPI.Service;
using EURO2024Stat.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test_PrivateCountry
{
	public class Test_PrivateCountry
	{
		private readonly DbContextOptions<CountryContext> _options;
		private readonly CountryContext _context;
		private readonly PrivateCountryService _service;


		public Test_PrivateCountry()
		{
			_options = new DbContextOptionsBuilder<CountryContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new CountryContext(_options);
			_service = new PrivateCountryService(_context);

			MockDbSetExtensions.SeedData_PublicCountryContext(_context);
		}

		[Fact]
		public async Task GetGroupWinners_ReturnsTopTwoCountriesFromEachGroup()
		{
			// Act
			var result = await _service.GetGroupWinners();

			// Assert
			Assert.Equal(2, result.Count);
			Assert.Contains(result, c => c.CountryName == "Germany");
			Assert.Contains(result, c => c.CountryName == "Switzerland");
		}

		[Fact]
		public async Task RollBackStatistic_UpdatesCountryStatistics()
		{
			// Arrange
			var homeCountryId = 2;
			var awayCountryId = 3;
			var homeGoals = 3;
			var awayGoals = 2;

			// Act
			await _service.RollBackStatistic(homeCountryId, awayCountryId, homeGoals, awayGoals);

			// Assert
			var homeCountry = await _context.Countries.FirstOrDefaultAsync(c => c.ID == homeCountryId);
			var awayCountry = await _context.Countries.FirstOrDefaultAsync(c => c.ID == awayCountryId);

			Assert.Equal(2, homeCountry.Matches);
			Assert.Equal(2, awayCountry.Matches);

			Assert.Equal(5, homeCountry.GoalsFor);
			Assert.Equal(0, homeCountry.GoalsAgainst);

			Assert.Equal(3, awayCountry.GoalsFor);
			Assert.Equal(0, awayCountry.GoalsAgainst);

			Assert.Equal(4, homeCountry.Point);
			Assert.Equal(5, awayCountry.Point);
		}
	}
}
