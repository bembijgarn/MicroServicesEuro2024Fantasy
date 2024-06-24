using Euro2024Stat.MatchAPI.Commands;
using Euro2024Stat.MatchAPI.Interface;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class ResetMatchCommandHandler : IRequestHandler<ResetMatchCommand, Unit>
    {
        private readonly IPrivateMatch _matchService;
        public ResetMatchCommandHandler(IPrivateMatch matchService) => _matchService = matchService;
        public async Task<Unit> Handle(ResetMatchCommand request, CancellationToken cancellationToken)
        {
            await _matchService.ResetMatch(request.matchId);
            return Unit.Value;
        }
    }
}
