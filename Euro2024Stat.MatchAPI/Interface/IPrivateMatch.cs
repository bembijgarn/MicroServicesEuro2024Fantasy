using EURO2024Stat.Domain;

namespace Euro2024Stat.MatchAPI.Interface
{
    public interface IPrivateMatch
    {
        Task EditMatchResult(int matchId, MatchResults model);
        Task ResetMatch(int matchId);
        Task FinishMatch(int matchId);
        Task CreatePlayOffMatch(Matches model);
        Task <List<int>> GetPlayoffMatchCountryIds(string group);
        Task<List<int>> GetPlayoffTeamIds(string group);
        Task<int> GetWinnerTeamId(string group);
        Task<int> GetLastMatchId();
        
    }
}
