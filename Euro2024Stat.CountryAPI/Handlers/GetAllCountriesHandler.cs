using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<Countries>>
    {
        private readonly IPublicCountry _countryService;

        public GetAllCountriesHandler(IPublicCountry countryservice) => _countryService = countryservice;
        public async Task<IEnumerable<Countries>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var Countries = await _countryService.GetAllCountry();
            return Countries;
        }
    }
}
