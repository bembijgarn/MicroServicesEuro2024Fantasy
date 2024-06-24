using MediatR;

namespace Euro2024Stat.WalletAPI.Command
{
    public record CreateWalletCommand(string userId, string userName) : IRequest<Unit>
    {
    }
}
