using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetMatchesWithResultsQuery : IRequest<IEnumerable<Matches>>
    {
    }
}
