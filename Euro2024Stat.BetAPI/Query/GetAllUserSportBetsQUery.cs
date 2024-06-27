using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Query
{
    public record GetAllUserSportBetsQUery : IRequest<IEnumerable<Bet>>
    {
    }
}
