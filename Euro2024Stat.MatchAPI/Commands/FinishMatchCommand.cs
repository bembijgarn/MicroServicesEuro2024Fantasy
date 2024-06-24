using MediatR;

namespace Euro2024Stat.MatchAPI.Commands
{
    public record FinishMatchCommand(int matchId) : IRequest<Unit>
    {
    }
}
