using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class GetGroupTop3ThPlacesHandler : IRequestHandler<GetGroupTop3thPlacesQuery, List<Countries>>
    {
        private readonly IPrivateCountry _countryService;

        public GetGroupTop3ThPlacesHandler(IPrivateCountry countryservice) => _countryService = countryservice;
        public async Task<List<Countries>> Handle(GetGroupTop3thPlacesQuery request, CancellationToken cancellationToken)
        {
            var top3ThCountries = await _countryService.GetGroupTop3ThPlace(request.countryIds);
            return top3ThCountries;
        }
    }
}
