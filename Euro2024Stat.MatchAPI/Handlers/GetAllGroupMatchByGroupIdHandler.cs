using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetAllGroupMatchByGroupIdHandler : IRequestHandler<GetAllGroupMatchByGroupIdQuery, IEnumerable<Matches>>
    {
        private readonly IPublicMatch _matchService;
        public GetAllGroupMatchByGroupIdHandler(IPublicMatch matchService) => _matchService = matchService;
        public async Task<IEnumerable<Matches>> Handle(GetAllGroupMatchByGroupIdQuery request, CancellationToken cancellationToken)
        {
            var GroupMatches = await _matchService.GetAllGroupMatchByGroupId(request.groupId);
            return GroupMatches;
        }
    }
}
