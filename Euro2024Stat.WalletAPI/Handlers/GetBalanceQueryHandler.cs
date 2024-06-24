using Euro2024Stat.WalletAPI.Interface;
using Euro2024Stat.WalletAPI.Query;
using MediatR;

namespace Euro2024Stat.WalletAPI.Handlers
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, decimal>
    {
        private readonly IWallet _walletService;

        public GetBalanceQueryHandler(IWallet walletService)
        {
            _walletService = walletService;
        }

        public Task<decimal> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            var Balance = _walletService.GetBalance(request.userId);
            return Balance;
        }
    }
}
