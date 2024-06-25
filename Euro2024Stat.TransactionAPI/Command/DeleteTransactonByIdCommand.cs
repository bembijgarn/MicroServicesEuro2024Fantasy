using MediatR;

namespace Euro2024Stat.TransactionAPI.Command
{
	public record DeleteTransactonByIdCommand(int transactionId) : IRequest<Unit>
	{
	}
}
