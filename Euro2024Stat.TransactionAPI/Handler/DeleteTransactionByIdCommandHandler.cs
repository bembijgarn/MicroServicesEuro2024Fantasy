using Euro2024Stat.TransactionAPI.Command;
using Euro2024Stat.TransactionAPI.Interface;
using MediatR;

namespace Euro2024Stat.TransactionAPI.Handler
{
	public class DeleteTransactionByIdCommandHandler : IRequestHandler<DeleteTransactonByIdCommand, Unit>
	{
		private readonly IPrivateTransaction _transactionService;

		public DeleteTransactionByIdCommandHandler(IPrivateTransaction transactionService)
		{
			_transactionService = transactionService;
		}
		public async Task<Unit> Handle(DeleteTransactonByIdCommand request, CancellationToken cancellationToken)
		{
			await _transactionService.DeleteTransactionById(request.transactionId);
			return Unit.Value;
		}
	}
}
