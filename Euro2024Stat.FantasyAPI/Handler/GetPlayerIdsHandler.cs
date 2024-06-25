using Euro2024Stat.FantasyAPI.Interface;
using Euro2024Stat.FantasyAPI.Models.Dto;
using Euro2024Stat.FantasyAPI.Query;
using MediatR;

namespace Euro2024Stat.FantasyAPI.Handler
{
    public class GetPlayerIdsHandler : IRequestHandler<GetPlayerIdsQuery, IEnumerable<FantasyPlayerDto>>
    {
        private readonly IPublicFantasy _fantasyService;

        public GetPlayerIdsHandler(IPublicFantasy fantasyService)
        {
            _fantasyService = fantasyService;
        }
        public Task<IEnumerable<FantasyPlayerDto>> Handle(GetPlayerIdsQuery request, CancellationToken cancellationToken)
        {
            var Players = _fantasyService.GetPlayerIds(request.userId);
            return Players;
        }
    }
}
