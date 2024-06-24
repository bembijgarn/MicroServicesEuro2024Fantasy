using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetMatchesWithResultsHandler : IRequestHandler<GetMatchesWithResultsQuery, IEnumerable<Matches>>
    {
        private readonly IPublicMatch _matchService;
        public GetMatchesWithResultsHandler(IPublicMatch matchService) => _matchService = matchService;
        public Task<IEnumerable<Matches>> Handle(GetMatchesWithResultsQuery request, CancellationToken cancellationToken)
        {
            var MatchesWithResult = _matchService.GetMatchesWithResults();
            return MatchesWithResult;
        }
    }
}
