using Euro2024Stat.BetAPI.Command;
using Euro2024Stat.BetAPI.Interface;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class RollbackBetMatchCommandHandler : IRequestHandler<RollbackBetMatchCommand, Unit>
    {
        private readonly IPrivateBet _betService;

        public RollbackBetMatchCommandHandler(IPrivateBet betService)
        {
            _betService = betService;
        }


        public async Task<Unit> Handle(RollbackBetMatchCommand request, CancellationToken cancellationToken)
        {
            await _betService.RollbackBetMatch(request.matchId);
            return Unit.Value;
        }
    }
}
