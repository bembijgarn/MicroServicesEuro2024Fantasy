using Euro2024Stat.BetAPI.Command;
using Euro2024Stat.BetAPI.Interface;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class PlaceBetCommandHandler : IRequestHandler<PlaceBetCommand, bool>
    {
        private readonly IPublicBet _betService;

        public PlaceBetCommandHandler(IPublicBet betService) => _betService = betService;

        public async Task<bool> Handle(PlaceBetCommand request, CancellationToken cancellationToken) => await _betService.PlaceBet(request.model);
       
    }
}
