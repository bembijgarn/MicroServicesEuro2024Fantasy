using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Query
{
    public record GetAllUserTransactionsQuery : IRequest<IEnumerable<Transactions>>
    {
    }
}
