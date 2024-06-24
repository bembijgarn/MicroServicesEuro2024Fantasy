using MediatR;

namespace Euro2024Stat.WalletAPI.Query
{
    public record GetBalanceQuery (string userId) : IRequest<decimal>
    {
    }
}
