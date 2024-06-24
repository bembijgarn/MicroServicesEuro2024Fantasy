using EURO2024Stat.Domain;

namespace Euro2024Stat.FantasyAPI.Interface
{
    public interface IPublicFantasy
    {
        Task CreateTeam(FantasyTeam model);
        Task<bool> HaveUserFantasy(string userId);
        Task BuyPlayer(string userId, int playerId, string playerName);
    }
}
