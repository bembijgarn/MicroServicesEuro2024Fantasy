using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
	public class GetGroupWinnerCountriesHandler : IRequestHandler<GetGroupWinnerCountriesQuery, List<Countries>>
	{
		private readonly IPrivateCountry _countryService;

		public GetGroupWinnerCountriesHandler(IPrivateCountry countryservice) => _countryService = countryservice;
		public async Task<List<Countries>> Handle(GetGroupWinnerCountriesQuery request, CancellationToken cancellationToken)
		{
			var groupWinnerCountries = await _countryService.GetGroupWinners();
			return groupWinnerCountries;
		}
	}
}
