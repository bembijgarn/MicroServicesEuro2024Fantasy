using Euro2024Stat.TransactionAPI.Command;
using Euro2024Stat.TransactionAPI.Interface;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Handler
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Unit>
    {
        private readonly IPublicTransaction _transactionService;

        public CreateTransactionCommandHandler(IPublicTransaction transactionService) => _transactionService = transactionService;

        public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            await _transactionService.CreateTransaction(request.model);
            return Unit.Value;
        }
    }
}
