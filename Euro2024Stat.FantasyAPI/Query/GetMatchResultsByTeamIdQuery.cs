using Euro2024Stat.FantasyAPI.Models.Dto;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Query
{
    public record GetMatchResultsByTeamIdQuery(int teamId) : IRequest<List<FantasyMatchResultDto>>
    {
    }
}
