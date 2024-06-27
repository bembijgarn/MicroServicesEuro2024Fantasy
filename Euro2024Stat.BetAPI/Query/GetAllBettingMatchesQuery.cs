using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Query
{
    public record GetAllBettingMatchesQuery : IRequest<IEnumerable<BetMatches>>
    {
    }
}
