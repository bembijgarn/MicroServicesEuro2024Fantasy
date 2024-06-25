using Euro2024Stat.MatchAPI.Interface;
using Euro2024Stat.MatchAPI.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Euro2024Stat.MatchAPI.Handlers
{
    public class GetPlayoffMatchCountryIdsByGroupHandler : IRequestHandler<GetPlayoffMatchCountryIdsByGroupQuery, List<int>>
    {
        private readonly IPrivateMatch _matchService;

        public GetPlayoffMatchCountryIdsByGroupHandler(IPrivateMatch matchService)
        {
            _matchService = matchService;
        }

        public async Task<List<int>> Handle(GetPlayoffMatchCountryIdsByGroupQuery request, CancellationToken cancellationToken)
        {
            var countryIds = await _matchService.GetPlayoffMatchCountryIds(request.group);
            return countryIds;
        }
    }
}
