using Euro2024Stat.MatchAPI.Commands;
using Euro2024Stat.MatchAPI.Interface;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class EditMatchResultCommandHandler : IRequestHandler<EditMatchResultCommand, Unit>
    {
        private readonly IPrivateMatch _matchService;
        public EditMatchResultCommandHandler(IPrivateMatch matchService) => _matchService = matchService;

        public async Task<Unit> Handle(EditMatchResultCommand request, CancellationToken cancellationToken)
        {
            await _matchService.EditMatchResult(request.matchId, request.model);
            return Unit.Value;
        }
       
    }
}
