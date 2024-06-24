using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IFantasy
    {
        Task<ResponseDto> CreateFantasyTeam(FantasyTeamDto model);
        Task<ResponseDto> HaveUserFantasy(string userId);
        Task<ResponseDto> BuyPlayer(string userId, int playerId, string playerName);


    }
}
