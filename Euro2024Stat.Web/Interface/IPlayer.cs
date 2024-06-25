using Euro2024Stat.Web.Models;
using Euro2024Stat.Web.Models.Dto;

namespace Euro2024Stat.Web.Interface
{
    public interface IPlayer
    {
        Task<ResponseDto?> GetPlayerByCountryId(int countryId);
        Task<ResponseDto?> GetPlayerById(int playerId);
        Task<ResponseDto> GetPlayersByPlayerIds(List<FantasyPlayerDto> playerIds);



    }
}
