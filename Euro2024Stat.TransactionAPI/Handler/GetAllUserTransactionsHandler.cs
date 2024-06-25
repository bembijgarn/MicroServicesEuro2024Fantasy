using Euro2024Stat.TransactionAPI.Interface;
using Euro2024Stat.TransactionAPI.Query;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Handler
{
    public class GetAllUserTransactionsHandler : IRequestHandler<GetAllUserTransactionsQuery, IEnumerable<Transactions>>
    {
        private readonly IPrivateTransaction _transactionService;

        public GetAllUserTransactionsHandler(IPrivateTransaction transactionService)
        {
            _transactionService = transactionService;
        }

        public Task<IEnumerable<Transactions>> Handle(GetAllUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            var Transactions = _transactionService.GetAllUserTransactions();
            return Transactions;
        }
    }
}
