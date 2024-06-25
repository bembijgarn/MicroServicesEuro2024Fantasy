using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetPlayoffTeamIdsQuery(string group) : IRequest<List<int>>
    {
    }
}
