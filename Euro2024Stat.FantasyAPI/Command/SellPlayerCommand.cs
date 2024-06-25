using MediatR;

namespace Euro2024Stat.FantasyAPI.Command
{
    public record SellPlayerCommand(string userId, int playerId) : IRequest<Unit>
    {
    }
}
