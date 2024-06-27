using Euro2024Stat.BetAPI.Interface;
using Euro2024Stat.BetAPI.Query;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class GetAllUserSportBetsHandler : IRequestHandler<GetAllUserSportBetsQUery, IEnumerable<Bet>>
    {
        private readonly IPrivateBet _betService;

        public GetAllUserSportBetsHandler(IPrivateBet betService)
        {
            _betService = betService;
        }

        public async Task<IEnumerable<Bet>> Handle(GetAllUserSportBetsQUery request, CancellationToken cancellationToken) => await _betService.GetAllUserSportBets();
       
    }
}
