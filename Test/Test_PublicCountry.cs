using EURO2024Stat.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using Euro2024Stat.CountryAPI.Service;

namespace Test_PublicCountry
{
	public class Test_PublicCountry
	{
		private readonly DbContextOptions<CountryContext> _options;
		private readonly CountryContext _context;
		private readonly PublicCountryService _service;


		public Test_PublicCountry()
		{
			_options = new DbContextOptionsBuilder<CountryContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new CountryContext(_options);
			_service = new PublicCountryService(_context);

			MockDbSetExtensions.SeedData_PublicCountryContext(_context);
		}

		[Fact]
		public async Task GetAllCountry_ReturnsAllCountries()
		{
			// Act
			var result = await _service.GetAllCountry();

			// Assert
			Assert.NotEmpty(result);
		}

		[Fact]
		public async Task GetCountriesByGroupId_ReturnsAllGroupCountries()
		{
			// Arrange

			char group = 'A';

			// Act
			var result = await _service.GetCountriesByGroup(group);

			// Assert
			Assert.Equal(4, result.Count());
		}

		[Fact]
		public async Task GetCountriesByd_ReturnsCountryById()
		{
			// Arrange

			int Id = 2;

			// Act
			var result = await _service.GetCountryById(Id);

			// Assert
			Assert.NotNull(result);
		}
	}
}
