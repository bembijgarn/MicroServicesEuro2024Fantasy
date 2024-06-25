using MediatR;

namespace Euro2024Stat.FantasyAPI.Command
{
    public record CreateMatchResultCommand(int teamId, string result) : IRequest<Unit>
    {
    }
}
