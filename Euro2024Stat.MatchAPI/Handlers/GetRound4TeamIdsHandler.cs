using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetRound4TeamIdsHandler : IRequestHandler<GetPlayoffTeamIdsQuery, List<int>>
    {
        private readonly IPrivateMatch _matchService;

        public GetRound4TeamIdsHandler (IPrivateMatch matchService)
        {
            _matchService = matchService;
        }

        public async Task<List<int>> Handle(GetPlayoffTeamIdsQuery request, CancellationToken cancellationToken)
        {
            var teamIds = await _matchService.GetPlayoffTeamIds(request.group);
            return teamIds;
        }
    }
}
