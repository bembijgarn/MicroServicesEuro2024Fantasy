using Euro2024Stat.CountryAPI.Commands;
using Euro2024Stat.CountryAPI.Interface;
using MediatR;

namespace Euro2024Stat.CountryAPI.Handlers
{
    public class UpdateStatisticCommandHandler : IRequestHandler<UpdateStatisticCommand, Unit>
    {
        private readonly IPrivateCountry _countryService;

        public UpdateStatisticCommandHandler(IPrivateCountry countryservice) => _countryService = countryservice;

        public async Task<Unit> Handle(UpdateStatisticCommand request, CancellationToken cancellationToken)
        {
            await _countryService.UpdateStatistic(request.homeCountryId, request.awayCountryId, request.homeGoals, request.awayGoals);
            return Unit.Value;
        }
    }
}
