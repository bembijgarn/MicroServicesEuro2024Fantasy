using MediatR;

namespace Euro2024Stat.FantasyAPI.Query
{
    public record GetTeamIdByUserIdQuery(string userid) : IRequest<int>
    {
    }
}
