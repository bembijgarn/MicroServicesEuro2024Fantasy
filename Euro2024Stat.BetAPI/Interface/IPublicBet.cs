using EURO2024Stat.Domain;

namespace Euro2024Stat.BetAPI.Interface
{
    public interface IPublicBet
    {
        Task<IEnumerable<BetMatches>> GetAllBettingMatches();
        Task <bool> PlaceBet(Bet model);
        Task<IEnumerable<Bet>> GetBetsByUserId(string userId);
    }
}
