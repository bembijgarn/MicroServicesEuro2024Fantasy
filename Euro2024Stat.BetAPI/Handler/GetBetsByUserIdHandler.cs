using Euro2024Stat.BetAPI.Interface;
using Euro2024Stat.BetAPI.Query;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class GetBetsByUserIdHandler : IRequestHandler<GetBetsByUserIdQuery, IEnumerable<Bet>>
    {
        private readonly IPublicBet _betService;

        public GetBetsByUserIdHandler(IPublicBet betService)
        {
            _betService = betService;
        }

        public async Task<IEnumerable<Bet>> Handle(GetBetsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userBets = await _betService.GetBetsByUserId(request.userId);
            return userBets;
        }
    }
}
