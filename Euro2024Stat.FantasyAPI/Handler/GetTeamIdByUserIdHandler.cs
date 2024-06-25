using Euro2024Stat.FantasyAPI.Interface;
using Euro2024Stat.FantasyAPI.Query;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class GetTeamIdByUserIdHandler : IRequestHandler<GetTeamIdByUserIdQuery, int>
    {
        private readonly IPublicFantasy _fantasyService;

        public GetTeamIdByUserIdHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public async Task<int> Handle(GetTeamIdByUserIdQuery request, CancellationToken cancellationToken)
        {
            int teamId = await _fantasyService.GetTeamIdByUserId(request.userid);
            return teamId;
        }
    }
}
