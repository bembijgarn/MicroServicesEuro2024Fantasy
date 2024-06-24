using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Countries>
    {
        private readonly IPublicCountry _countryService;

        public GetCountryByIdHandler(IPublicCountry countryservice) => _countryService = countryservice;
        public Task<Countries> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var Country = _countryService.GetCountryById(request.Id);
            return Country;
        }
    }
}
