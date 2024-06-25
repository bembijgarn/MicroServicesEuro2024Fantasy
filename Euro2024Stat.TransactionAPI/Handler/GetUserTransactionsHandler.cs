using Euro2024Stat.TransactionAPI.Interface;
using Euro2024Stat.TransactionAPI.Query;
using EURO2024Stat.DATA.Migrations.Transaction;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Handler
{
    public class GetUserTransactionsHandler : IRequestHandler<GetUserTransactionsQuery, IEnumerable<Transactions>>
    {
        private readonly IPublicTransaction _transactionService;

        public GetUserTransactionsHandler(IPublicTransaction transactionService) => _transactionService = transactionService;
        public Task<IEnumerable<Transactions>> Handle(GetUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            var userTransactions = _transactionService.GetUserTransactions(request.userId);
            return userTransactions;
        }
    }
}
