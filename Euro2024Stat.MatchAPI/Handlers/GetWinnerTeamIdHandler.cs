using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetWinnerTeamIdHandler : IRequestHandler<GetWinnerTeamIdQuery, int>
    {
        private readonly IPrivateMatch _matchService;

        public GetWinnerTeamIdHandler(IPrivateMatch matchService)
        {
            _matchService = matchService;
        }

        public async Task<int> Handle(GetWinnerTeamIdQuery request, CancellationToken cancellationToken)
        {
            var winnerTeamId = await _matchService.GetWinnerTeamId(request.groupId);
            return winnerTeamId;
        }
    }
}
