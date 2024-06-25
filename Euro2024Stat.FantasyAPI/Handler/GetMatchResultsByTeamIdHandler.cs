using Euro2024Stat.FantasyAPI.Interface;
using Euro2024Stat.FantasyAPI.Models.Dto;
using Euro2024Stat.FantasyAPI.Query;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class GetMatchResultsByTeamIdHandler : IRequestHandler<GetMatchResultsByTeamIdQuery, List<FantasyMatchResultDto>>
    {
        private readonly IPublicFantasy _fantasyService;

        public GetMatchResultsByTeamIdHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public async Task<List<FantasyMatchResultDto>> Handle(GetMatchResultsByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var fantasyMatchResults = await _fantasyService.GetMatchResultsByTeamId(request.teamId);
            return fantasyMatchResults.ToList();
        }
    }
}
