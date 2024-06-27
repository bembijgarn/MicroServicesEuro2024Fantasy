using MediatR;

namespace Euro2024Stat.BetAPI.Command
{
    public record FinishBetMatchCommand(int matchId) : IRequest<Unit>
    {
    }
}
