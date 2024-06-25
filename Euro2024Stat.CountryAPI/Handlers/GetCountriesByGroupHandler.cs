using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class GetCountriesByGroupHandler : IRequestHandler<GetCountriesByGroupQuery, IEnumerable<Countries>>
    {
        private readonly IPublicCountry _countryService;

        public GetCountriesByGroupHandler(IPublicCountry countryservice) => _countryService = countryservice;
        public Task<IEnumerable<Countries>> Handle(GetCountriesByGroupQuery request, CancellationToken cancellationToken)
        {
            var Countries = _countryService.GetCountriesByGroup(request.group);
            return Countries;
        }
    }
}
