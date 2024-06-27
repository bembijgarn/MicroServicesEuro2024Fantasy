using MediatR;

namespace Euro2024Stat.BetAPI.Command
{
    public record RollbackBetMatchCommand(int matchId) : IRequest<Unit>
    {
    }
}
