using Euro2024Stat.PlayerAPI.Interface;
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

        async Task<IEnumerable<Player>> IPlayer.GetPlayerByCountryId(int CountryId) => await Task.FromResult(_db.Players.Where(x => x.CountryID == CountryId));
        
    }
}
