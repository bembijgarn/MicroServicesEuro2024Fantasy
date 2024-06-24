using MediatR;

namespace Euro2024Stat.FantasyAPI.Command
{
    public record BuyPlayerCommand(string userId, int playerId, string playerName) : IRequest<Unit>
    {
    }
}
