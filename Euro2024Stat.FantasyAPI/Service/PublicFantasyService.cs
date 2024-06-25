using Euro2024Stat.FantasyAPI.Interface;
using Euro2024Stat.FantasyAPI.Models.Dto;
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

        public async Task SellPlayer(string userId, int playerId)
        {
            var userTeam  = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == userId);
            if (userTeam != null)
            {
                var player = await  _db.TeamPlayers.SingleOrDefaultAsync(x => x.PlayerId == playerId && x.UserID == userId);
                if (player != null)
                {
                    _db.TeamPlayers.Remove(player);
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

        public async Task<IEnumerable<FantasyPlayerDto>> GetPlayerIds(string userId)
        {
            var checkfantasyteam = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == userId);
            if (checkfantasyteam != null)
            {
                var playerIds = await _db.TeamPlayers
                                        .Where(tp => tp.UserID == userId)
                                        .Select(tp => new FantasyPlayerDto { PlayerId = tp.PlayerId })
                                        .ToListAsync();

                return playerIds;
            }
            return Enumerable.Empty<FantasyPlayerDto>(); 
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

        public async Task<int> GetTeamIdByUserId(string userId)
        {
            var team = await _db.Teams.SingleOrDefaultAsync(x => x.UserId == userId);
            if (team != null)
            {
                return team.ID;
            }
            return 0;
        }

        public async Task CreateMatchResult(int teamId, string result)
        {
            var team = await _db.Teams.SingleOrDefaultAsync(x => x.ID == teamId);
            if (team != null)
            {
                var matchResult = new FantasyMatchResults()
                {
                    TeamID = teamId,
                    Result = result
                };

                _db.MatchResults.Add(matchResult);
                await _db.SaveChangesAsync();
            }
        }
    }
}
