using MediatR;

namespace Euro2024Stat.WalletAPI.Command
{
    public record DepositCommand(string userId, decimal amount) : IRequest<Unit>
    {
    }
}
