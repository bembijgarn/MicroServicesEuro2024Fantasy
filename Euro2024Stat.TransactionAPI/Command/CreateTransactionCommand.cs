using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Command
{
    public record CreateTransactionCommand(Transactions model) : IRequest<Unit>
    {
    }
}
