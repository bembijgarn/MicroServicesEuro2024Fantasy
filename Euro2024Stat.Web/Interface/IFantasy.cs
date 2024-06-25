using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Models.Dto;

namespace Euro2024Stat.Web.Interface
{
    public interface IFantasy
    {
        Task<ResponseDto> CreateFantasyTeam(FantasyTeamDto model);
        Task<ResponseDto> HaveUserFantasy(string userId);
        Task<ResponseDto> BuyPlayer(string userId, int playerId, string playerName);
        Task<ResponseDto> SellPlayer(string userId, int playerId);

        Task<ResponseDto> GetFantasyPlayers(string userId);
        Task<ResponseDto> GetTeamIdByUserId(string userId);
        Task<ResponseDto> CreateMatchResult(int teamId, string result);





    }
}
