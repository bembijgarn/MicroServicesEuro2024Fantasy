using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetAllGroupMatchWithResultBygroupIdQuery(string groupId) : IRequest<IEnumerable<Matches>>
    {
    }
}
