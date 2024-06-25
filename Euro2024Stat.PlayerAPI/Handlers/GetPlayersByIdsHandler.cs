using Euro2024Stat.PlayerAPI.Interface;
using Euro2024Stat.PlayerAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Handlers
{
    public class GetPlayersByIdsHandler : IRequestHandler<GetPlayersByIdsQuery, IEnumerable<Player>>
    {
        private readonly IPlayer _playerService;

        public GetPlayersByIdsHandler(IPlayer player) => _playerService = player;

        public async Task<IEnumerable<Player>> Handle(GetPlayersByIdsQuery request, CancellationToken cancellationToken)
        {
            var players = await _playerService.GetPlayersByPlayerIds(request.playerIds);
            return players;
        }
    }
}
