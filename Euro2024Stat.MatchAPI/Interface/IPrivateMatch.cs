using EURO2024Stat.Domain;

namespace Euro2024Stat.MatchAPI.Interface
{
    public interface IPrivateMatch
    {
        Task EditMatchResult(int matchId, MatchResults model);
        Task ResetMatch(int matchId);
        Task FinishMatch(int matchId);
        
    }
}
