using Euro2024Stat.PlayerAPI.Interface;
using Euro2024Stat.PlayerAPI.Models.Dto;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.PlayerAPI.Service
{
    public class PlayerService : IPlayer
    {
        private readonly PlayerContext _db;


        public PlayerService(PlayerContext db) => _db = db; 
        public async Task<IEnumerable<Player>> GetAllPlayer() => await Task.FromResult(_db.Players);

       

        public async Task<Player> GetPlayerById(int Id)
        {
            var Player = await _db.Players.FirstOrDefaultAsync(x => x.ID == Id);
            return Player;
        }

        public async Task<IEnumerable<Player>> GetPlayersByPlayerIds(List<FantasyPlayerDto> playerDto)
        {
            var playerIds = playerDto.Select(dto => dto.PlayerId).ToList();

            var players = await _db.Players.Where(x => playerIds.Contains(x.ID)).ToListAsync();
            return players;
        }


        async Task<IEnumerable<Player>> IPlayer.GetPlayerByCountryId(int CountryId) => await Task.FromResult(_db.Players.Where(x => x.CountryID == CountryId));
        
    }
}
