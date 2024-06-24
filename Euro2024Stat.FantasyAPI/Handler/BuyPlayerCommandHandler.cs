using Euro2024Stat.FantasyAPI.Command;
using Euro2024Stat.FantasyAPI.Interface;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class BuyPlayerCommandHandler : IRequestHandler<BuyPlayerCommand, Unit>
    {
        private readonly IPublicFantasy _fantasyService;

        public BuyPlayerCommandHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public async Task<Unit> Handle(BuyPlayerCommand request, CancellationToken cancellationToken)
        {
            await _fantasyService.BuyPlayer(request.userId, request.playerId, request.playerName);
            return Unit.Value;
        }
    }
}
