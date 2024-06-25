using Euro2024Stat.FantasyAPI.Command;
using Euro2024Stat.FantasyAPI.Interface;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class SellPlayerCommandHandler : IRequestHandler<SellPlayerCommand, Unit>
    {
        private readonly IPublicFantasy _fantasyService;

        public SellPlayerCommandHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }

        public async Task<Unit> Handle(SellPlayerCommand request, CancellationToken cancellationToken)
        {
            await _fantasyService.SellPlayer(request.userId, request.playerId);
            return Unit.Value;
        }
    }
}
