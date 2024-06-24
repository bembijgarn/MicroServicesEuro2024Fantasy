using Euro2024Stat.WalletAPI.Command;
using Euro2024Stat.WalletAPI.Interface;
using MediatR;

namespace Euro2024Stat.WalletAPI.Handlers
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Unit>
    {
        private readonly IWallet _walletService;

        public CreateWalletCommandHandler (IWallet walletservice) => _walletService = walletservice;
        public async Task<Unit> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            await _walletService.CreateWallet(request.userId, request.userName);
            return Unit.Value;
        }
    }
}
