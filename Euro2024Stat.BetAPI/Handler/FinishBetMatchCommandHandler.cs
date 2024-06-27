using Euro2024Stat.BetAPI.Command;
using Euro2024Stat.BetAPI.Interface;
using MediatR;

namespace Euro2024Stat.BetAPI.Handler
{
    public class FinishBetMatchCommandHandler : IRequestHandler<FinishBetMatchCommand, Unit>
    {
        private readonly IPrivateBet _betService;

        public FinishBetMatchCommandHandler(IPrivateBet betService)
        {
            _betService = betService;
        }
        public async Task<Unit> Handle(FinishBetMatchCommand request, CancellationToken cancellationToken)
        {
            await _betService.FinishBetMatch(request.matchId);
            return Unit.Value;
        }
    }
}
