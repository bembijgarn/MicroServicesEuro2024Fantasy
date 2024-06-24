using Euro2024Stat.PlayerAPI.Interface;
using Euro2024Stat.PlayerAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Handlers
{
    public class GetAllPlayerHandler : IRequestHandler<GetAllPlayerQuery, IEnumerable<Player>>
    {
        private readonly IPlayer _playerService;

        public GetAllPlayerHandler(IPlayer player) => _playerService = player;
        public async Task<IEnumerable<Player>> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
        {
            var Players = await _playerService.GetAllPlayer();
            return Players;
        }
    }
}
