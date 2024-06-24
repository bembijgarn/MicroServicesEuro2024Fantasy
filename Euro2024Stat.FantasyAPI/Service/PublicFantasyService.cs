using Euro2024Stat.FantasyAPI.Interface;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.FantasyAPI.Service
{
    public class PublicFantasyService : IPublicFantasy
    {
        private readonly FantasyContext _db;

        public PublicFantasyService (FantasyContext db) => _db = db;

        public async Task BuyPlayer(string userId, int playerId, string playerName)
        {
            var userTeam = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == userId);
            if (userTeam != null)
            {
                var checkPlayerId = _db.TeamPlayers.SingleOrDefault(x => x.PlayerId == playerId && x.UserID == userId);
                if (checkPlayerId == null)
                {
                    var FantasyTeamPlayer = new FantasyTeamPlayers()
                    {
                        UserID = userId,
                        PlayerId = playerId,
                        PlayerName = playerName
                    };
                    _db.TeamPlayers.Add(FantasyTeamPlayer);
                    await _db.SaveChangesAsync();
                }
               
            }
        }

        public async Task CreateTeam(FantasyTeam model)
        {
            var checkfantasyteam = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == model.UserId);
            if (checkfantasyteam == null)
            {
                _db.Teams.Add(model);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> HaveUserFantasy(string userId)
        {
            var checkfantasyteam = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == userId);
            if (checkfantasyteam != null)
            {
                return true;
            }
            return false;
        }
    }
}
