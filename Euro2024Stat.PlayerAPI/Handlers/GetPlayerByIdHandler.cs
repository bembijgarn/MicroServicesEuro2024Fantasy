using Euro2024Stat.PlayerAPI.Interface;
using Euro2024Stat.PlayerAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Handlers
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly IPlayer _playerService;

        public GetPlayerByIdHandler(IPlayer player) => _playerService = player;
        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var Player = await _playerService.GetPlayerById(request.Id);
            return Player;
        }
    }
}
