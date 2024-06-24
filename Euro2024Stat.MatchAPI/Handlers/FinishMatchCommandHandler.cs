using Euro2024Stat.MatchAPI.Commands;
using Euro2024Stat.MatchAPI.Interface;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class FinishMatchCommandHandler : IRequestHandler<FinishMatchCommand, Unit>
    {
        private readonly IPrivateMatch _matchService;
        public FinishMatchCommandHandler(IPrivateMatch matchService) => _matchService = matchService;
        public async Task<Unit> Handle(FinishMatchCommand request, CancellationToken cancellationToken)
        {
            await _matchService.FinishMatch(request.matchId);
            return Unit.Value;
        }
    }
}
