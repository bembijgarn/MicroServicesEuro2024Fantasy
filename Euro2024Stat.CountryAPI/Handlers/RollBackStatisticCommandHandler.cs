using Euro2024Stat.CountryAPI.Commands;
using Euro2024Stat.CountryAPI.Interface;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class RollBackStatisticCommandHandler : IRequestHandler<RollBackStatisticCommand, Unit>
    {
        private readonly IPrivateCountry _countryService;

        public RollBackStatisticCommandHandler(IPrivateCountry countryservice) => _countryService = countryservice;
        public async Task<Unit> Handle(RollBackStatisticCommand request, CancellationToken cancellationToken)
        {
            await _countryService.RollBackStatistic(request.homeCountryId, request.awayCountryId, request.homeGoals, request.awayGoals);
            return Unit.Value;
        }
    }
}
