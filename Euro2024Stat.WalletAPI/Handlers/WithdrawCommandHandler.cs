using Euro2024Stat.WalletAPI.Command;
using Euro2024Stat.WalletAPI.Interface;
using MediatR;

namespace Euro2024Stat.WalletAPI.Handlers
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, bool>
    {
        private readonly IWallet _walletService;

        public WithdrawCommandHandler(IWallet walletservice) => _walletService = walletservice;

        public async Task<bool> Handle(WithdrawCommand request, CancellationToken cancellationToken) => await _walletService.Withdraw(request.userId, request.amount);

    }
}
