using Euro2024Stat.WalletAPI.Command;
using Euro2024Stat.WalletAPI.Interface;
using MediatR;

namespace Euro2024Stat.WalletAPI.Handlers
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Unit>
    {
        private readonly IWallet _walletService;

        public DepositCommandHandler(IWallet walletservice) => _walletService = walletservice;
        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            await _walletService.Deposit(request.userId, request.amount);
            return Unit.Value;
        }
    }
}
