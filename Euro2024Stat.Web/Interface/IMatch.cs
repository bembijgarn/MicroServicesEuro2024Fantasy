using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
	public interface IMatch
	{
		Task<ResponseDto?> GetAllMatch();
		Task<ResponseDto?> GetCountryMatches(int Id);
        Task<ResponseDto?> GetMatchesWithResults();
        Task<ResponseDto?> EditMatchResult(int matchId, MatchResultDto model);
        Task<ResponseDto?> ResetMatch(int matchId);
        Task<ResponseDto?> FinishMatch(int matchId);
        Task<ResponseDto?> GetAllGroupMatchByGroupId(string groupId);
        Task<ResponseDto?> GetGroupMatchResultsByGroupId(string groupId);
        Task<ResponseDto?> CreatePlayOffMatch(PlayoffMatchDto model);
        Task<ResponseDto?> GetPlayoffCountryIdsByGroup(string groupId);
        Task<ResponseDto?> GetPlayoffWinnerTeamIds(string groupId);
        Task<ResponseDto?> GetWinnerTeamId(string groupId);
        Task<ResponseDto?> GetLastMatchId();

        





    }
}
