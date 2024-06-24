using MediatR;

namespace Euro2024Stat.WalletAPI.Command
{
    public record WithdrawCommand(string userId, decimal amount) : IRequest<bool>
    {
    }
}
