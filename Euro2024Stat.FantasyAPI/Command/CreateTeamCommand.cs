using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Command
{
    public record CreateTeamCommand(FantasyTeam model) : IRequest<Unit>
    {
    }
}
