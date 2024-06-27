using EURO2024Stat.Domain;
using System.Runtime.CompilerServices;

namespace Euro2024Stat.BetAPI.Interface
{
    public interface IPrivateBet
    {
        Task<IEnumerable<Bet>> GetAllUserSportBets();
        Task <bool> UpdateBetStatus (string betId, string betStatus);
        Task FinishBetMatch(int matchId);
        Task RollbackBetMatch(int matchId);
        Task AddPlayoffBetMatch(BetMatches model);

    }
}
