using MediatR;

namespace Euro2024Stat.MatchAPI.Commands
{
    public record ResetMatchCommand(int matchId) : IRequest<Unit>
    {
    }
}
