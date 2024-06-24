using Euro2024Stat.Web.Models;

namespace Euro2024Stat.Web.Interface
{
    public interface IPlayer
    {
        Task<ResponseDto?> GetPlayerByCountryId(int countryId);
        Task<ResponseDto?> GetPlayerById(int playerId);


    }
}
