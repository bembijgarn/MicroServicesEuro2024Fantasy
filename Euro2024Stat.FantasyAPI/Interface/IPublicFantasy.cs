using Euro2024Stat.FantasyAPI.Models.Dto;
using EURO2024Stat.Domain;

namespace Euro2024Stat.FantasyAPI.Interface
{
    public interface IPublicFantasy
    {
        Task CreateTeam(FantasyTeam model);
        Task<bool> HaveUserFantasy(string userId);
        Task BuyPlayer(string userId, int playerId, string playerName);
        Task SellPlayer(string userId, int playerId);
        Task<IEnumerable<FantasyPlayerDto>> GetPlayerIds(string userId);
        Task<int> GetTeamIdByUserId(string userId);
        Task CreateMatchResult(int teamId, string result);
    }
}
