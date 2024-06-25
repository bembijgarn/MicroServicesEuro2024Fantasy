using Euro2024Stat.MatchAPI.Commands;
using Euro2024Stat.MatchAPI.Interface;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class CreatePlayOffMatchCommandHandler : IRequestHandler<CreatePlayOffMatchCommand, Unit>
    {
        private readonly IPrivateMatch _matchService;
        public CreatePlayOffMatchCommandHandler(IPrivateMatch matchService) => _matchService = matchService;

        public async Task<Unit> Handle(CreatePlayOffMatchCommand request, CancellationToken cancellationToken)
        {
            await _matchService.CreatePlayOffMatch(request.model);
            return Unit.Value;
        }
    }
}
