using MediatR;

namespace Euro2024Stat.MatchAPI.Queries
{
    public record GetWinnerTeamIdQuery(string groupId) : IRequest<int>
    {
    }
}
