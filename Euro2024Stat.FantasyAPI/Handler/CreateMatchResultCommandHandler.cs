using Euro2024Stat.FantasyAPI.Command;
using Euro2024Stat.FantasyAPI.Interface;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class CreateMatchResultCommandHandler : IRequestHandler<CreateMatchResultCommand, Unit>
    {
        private readonly IPublicFantasy _fantasyService;

        public CreateMatchResultCommandHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public async Task<Unit> Handle(CreateMatchResultCommand request, CancellationToken cancellationToken)
        {
            await _fantasyService.CreateMatchResult(request.teamId, request.result);
            return Unit.Value;
        }
    }
}
