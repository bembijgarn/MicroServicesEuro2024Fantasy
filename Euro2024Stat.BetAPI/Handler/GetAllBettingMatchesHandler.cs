using Euro2024Stat.BetAPI.Interface;
using Euro2024Stat.BetAPI.Query;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class GetAllBettingMatchesHandler : IRequestHandler<GetAllBettingMatchesQuery, IEnumerable<BetMatches>>
    {
        private readonly IPublicBet _betService;

        public GetAllBettingMatchesHandler(IPublicBet betService) => _betService = betService; 
        public async Task<IEnumerable<BetMatches>> Handle(GetAllBettingMatchesQuery request, CancellationToken cancellationToken)
        {
            var allBettingMatch = await _betService.GetAllBettingMatches();
            return allBettingMatch;
        }
    }
}
