using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetAllGroupMatchWithResultByGroupIdHandler : IRequestHandler<GetAllGroupMatchWithResultBygroupIdQuery, IEnumerable<Matches>>
    {
        private readonly IPublicMatch _matchService;
        public GetAllGroupMatchWithResultByGroupIdHandler(IPublicMatch matchService) => _matchService = matchService;
        public async Task<IEnumerable<Matches>> Handle(GetAllGroupMatchWithResultBygroupIdQuery request, CancellationToken cancellationToken)
        {
            var MatchesWithResult = await _matchService.GetAllGroupMatchWithResultByGroupId(request.groupId);
            return MatchesWithResult;
        }
    }
}
