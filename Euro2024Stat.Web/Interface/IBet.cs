using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IBet
    {
        Task<ResponseDto?> GetAllBettingMatch();
        Task<ResponseDto?> PlaceBet(BettingBetModelDto model);
        Task<ResponseDto?> GetAllUsersSportBets();
		Task<ResponseDto?> UpdateUserBetStatus(string betId, string betStatus);
        Task<ResponseDto?> FinishBetMatch(int matchId);
        Task<ResponseDto?> RollbackBetMatch(int matchId);
        Task<ResponseDto?> AddPlayoffBetMatch(BetMatchesDto model);
        Task<ResponseDto?> GetUserBetsByUserId(string userId);


    }
}
