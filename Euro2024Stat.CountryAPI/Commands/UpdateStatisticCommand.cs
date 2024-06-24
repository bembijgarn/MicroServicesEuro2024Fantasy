using MediatR;

namespace Euro2024Stat.CountryAPI.Commands
{
    public record UpdateStatisticCommand(int homeCountryId, int awayCountryId, int homeGoals, int awayGoals) : IRequest<Unit>
    {
    }
}
