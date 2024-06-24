using Euro2024Stat.FantasyAPI.Command;
using Euro2024Stat.FantasyAPI.Interface;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Unit>
    {
        private readonly IPublicFantasy _fantasyService;

        public CreateTeamCommandHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            await _fantasyService.CreateTeam(request.model);
            return Unit.Value;
        }
    }
}
