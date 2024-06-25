using Euro2024Stat.PlayerAPI.Models.Dto;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Queries
{
    public record GetPlayersByIdsQuery(List<FantasyPlayerDto> playerIds) : IRequest<IEnumerable<Player>>
    {
    }
}
