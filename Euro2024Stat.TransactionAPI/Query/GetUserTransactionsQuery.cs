using EURO2024Stat.Domain;
using MediatR;
using System.Transactions;

namespace Euro2024Stat.TransactionAPI.Query
{
    public record GetUserTransactionsQuery(string userId) : IRequest<IEnumerable<Transactions>>
    {
    }
}
