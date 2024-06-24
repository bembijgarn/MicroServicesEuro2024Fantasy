using Euro2024Stat.PlayerAPI.Interface;
using Euro2024Stat.PlayerAPI.Queries;
using EURO2024Stat.Domain;
using MediatR;

namespace Euro2024Stat.PlayerAPI.Handlers
{
    public class GetPlayerByCountryIdHandler : IRequestHandler<GetPlayersByCountryIdQuery, IEnumerable<Player>>
    {

        private readonly IPlayer _playerService;

        public GetPlayerByCountryIdHandler(IPlayer player) => _playerService = player;


        public async Task<IEnumerable<Player>> Handle(GetPlayersByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var Players = await _playerService.GetPlayerByCountryId(request.CountryId);
            return Players;
        }
    }
}
